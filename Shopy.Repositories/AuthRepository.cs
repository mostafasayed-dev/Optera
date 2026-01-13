using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Optera.DTOs.Core;
using Optera.DTOs.Country;
using Optera.DTOs.Employee;
using Optera.DTOs.Role;
using Optera.DTOs.User;
using Optera.Infrastructure.Interfaces;
using Optera.Infrastructure.Services;
using Optera.Models;
using Optera.Utils.Models;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Optera.Repositories
{
    public class AuthRepository<TUser, TRole> : IAuthRepository
            where TUser : User, new()
            where TRole : Role, new()
    {
        private readonly UserManager<TUser> userManager;
        private readonly RoleManager<TRole> roleManager;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmailService emailService;
        private readonly IConfiguration configuration;

        public AuthRepository(UserManager<TUser> userManager,
                              RoleManager<TRole> roleManager,
                              ITokenService tokenService,
                              IMapper mapper,
                              IEmployeeRepository employeeRepository,
                              IEmailService emailService,
                              IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.tokenService = tokenService;
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
            this.emailService = emailService;
            this.configuration = configuration;
        }

        public async Task<ServiceResponse<Token>> Login(LoginDTO loginDto)
        {
            try
            {
                var user = await userManager.FindByNameAsync(loginDto.Email);
                if (user != null && user.Id > 0)
                {
                    if(user.Locked)
                        return ServiceResponse<Token>.UserLocked(null, "User account locked! Please contact your system administrator.");

                    if (!user.EmailConfirmed)
                        return ServiceResponse<Token>.EmailNotConfirmed(null, "Email not confirmed! Please contact your system administrator.");

                    if (await userManager.CheckPasswordAsync(user, loginDto.Password))
                    {
                        var claims = new List<Claim>();
                        var userClaims = await userManager.GetClaimsAsync(user);
                        var roles = await userManager.GetRolesAsync(user);
                        claims.AddRange(userClaims);

                        foreach (var roleName in roles)
                        {
                            var role = await roleManager.FindByNameAsync(roleName);
                            var roleClaims = await roleManager.GetClaimsAsync(role);
                            claims.AddRange(roleClaims);
                        }


                        var token = tokenService.GenerateToken(claims);
                        token.UserId = user.Id;
                        return ServiceResponse<Token>.Succeeded(token, "User Logged in successfully.");
                    }
                    else
                    {
                        return ServiceResponse<Token>.InvalidUsernameOrPassword(null, "Login failed. Invalid username or password!");
                    }
                }
                else
                    return ServiceResponse<Token>.Failed(null, "Login failed!");
            }
            catch (Exception ex)
            {
                return ServiceResponse<Token>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<Token>> Register(RegisterDTO registerDto)
        {
            Token token = null;
            TUser newUser = null;
            try
            {
                newUser = new TUser { UserName = registerDto.Username, Email = registerDto.Email, PhoneNumber = registerDto.PhoneNumber };
                var result = await userManager.CreateAsync(newUser);

                if (result.Succeeded)
                {
                    if (newUser.Id > 0)
                    {
                        //assign roles to created user
                        var roleResult = await userManager.AddToRolesAsync(newUser, registerDto.Roles);

                        if (roleResult.Succeeded)
                        {
                            //assign user claims
                            var claimsResult = await userManager.AddClaimsAsync(newUser,
                            new List<Claim>() {
                            new Claim(JwtRegisteredClaimNames.Sub, newUser.Id.ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, newUser.UserName),
                                });

                            if (claimsResult.Succeeded)
                            {
                                // create employee
                                var employee = new CreateEmployeeDto
                                {
                                    Name = registerDto.EmployeeName,
                                    Email = registerDto.Email,
                                    Phone = registerDto.PhoneNumber,
                                    Gender = registerDto.EmployeeGender,
                                    DateOfBirth = registerDto.EmployeeDateOfBirth,
                                    NationalityId = registerDto.EmployeeNationalityId,
                                    PositionId = registerDto.EmployeePositionId,
                                    UserId = newUser.Id,
                                };
                                await employeeRepository.CreateEmployee(employee);
                                
                                //get user claims 
                                var claims = await userManager.GetClaimsAsync(newUser);
                                //generate token
                                token = tokenService.GenerateToken(claims);
                                token.UserId = newUser.Id;

                                // send reset password email
                                string resetToken = await userManager.GeneratePasswordResetTokenAsync(newUser);
                                string encodedToken = System.Web.HttpUtility.UrlEncode(resetToken);
                                emailService.SendNewAccountConfirmationEmail(registerDto.Email, registerDto.EmployeeName, registerDto.Username, configuration["AppSettings:Url"] + "/auth/reset-password?id=" + newUser.Id + "&token=" + encodedToken);
                            }
                            else
                            {
                                await userManager.DeleteAsync(newUser);
                                return ServiceResponse<Token>.Failed(null, GetErrors(claimsResult));
                            }
                        }
                        else
                        {
                            await userManager.DeleteAsync(newUser);
                            return ServiceResponse<Token>.Failed(null, GetErrors(roleResult));
                        }
                    }
                }
                else
                {
                    return ServiceResponse<Token>.Failed(null, GetErrors(result));
                }
                return ServiceResponse<Token>.Succeeded(token, "A new User created successfully.");
            }
            catch (Exception ex)
            {
                if (newUser?.Id > 0)
                    await userManager.DeleteAsync(newUser);
                return ServiceResponse<Token>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<bool>> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            try
            {
                var user = await userManager.FindByIdAsync(resetPasswordDto.Id.ToString());
                
                if(user == null)
                    return ServiceResponse<bool>.NotFound(true, "User not found.");

                var result = await userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password);

                if (result.Succeeded)
                {
                    user.EmailConfirmed = true;
                    await userManager.UpdateAsync(user);
                    return ServiceResponse<bool>.Succeeded(true, "Password reset successfully.");
                }
                else
                    return ServiceResponse<bool>.Failed(false, GetErrors(result));
            }
            catch (Exception ex)
            {
                return ServiceResponse<bool>.Failed(false, ex.Message);
            }
        }

        public async Task<ServiceResponse<PagedList<GetUserDTO>>> GetUsers(UserParams? userParams)
        {
            try
            {
                var users = userManager.Users.Include(x => x.Employee).ProjectTo<GetUserDTO>(mapper.ConfigurationProvider);
                var result = await PagedList<GetUserDTO>.CreatePageAsync(users, userParams);
                return ServiceResponse<PagedList<GetUserDTO>>.Succeeded(result, "Users retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetUserDTO>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<RegisterDTO>> GetUserById(int id)
        {
            try
            {
                var user = await userManager.Users.Include(x => x.Employee).Where(x => x.Id == id)
                                    .ProjectTo<RegisterDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

                if (user == null)
                    return ServiceResponse<RegisterDTO>.NotFound(null, "User not found!");

                var result = await userManager.FindByIdAsync(id.ToString());
                var roles = await userManager.GetRolesAsync(result);
                foreach (var role in roles)
                {
                    user.Roles.Add(role);
                }

                return ServiceResponse<RegisterDTO>.Succeeded(user, "User retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<RegisterDTO>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<PagedList<GetRoleDto>>> GetRoles(UserParams? userParams)
        {
            try
            {
                var users = roleManager.Roles.Where(x => x.NormalizedName != "ADMIN").ProjectTo<GetRoleDto>(mapper.ConfigurationProvider);
                var result = await PagedList<GetRoleDto>.CreatePageAsync(users, userParams);
                return ServiceResponse<PagedList<GetRoleDto>>.Succeeded(result, "Roles retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetRoleDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<ICollection<GetRoleListDto>>> GetRolesItemsList()
        {
            try
            {
                var roles = await roleManager.Roles.Where(p => p.Name.ToUpper().Trim() != "ADMIN").ToListAsync();
                if (roles == null)
                    throw new Exception("Can't retrieve Roles list!");
                roles = roles.OrderBy(p => p.Name).ToList();
                return ServiceResponse<ICollection<GetRoleListDto>>.Succeeded(mapper.Map<ICollection<GetRoleListDto>>(roles), "Roles list retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<ICollection<GetRoleListDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetRoleDto>> CreateRole(CreateRoleDto createRoleDto)
        {
            try
            {
                var roleEntity = new TRole
                {
                    Name = createRoleDto.Name.Trim(),
                    NormalizedName = createRoleDto.Name.ToUpper().Trim()
                };

                var result = await roleManager.CreateAsync(roleEntity);
                if (!result.Succeeded)
                    return ServiceResponse<GetRoleDto>.Failed(null, GetErrors(result));

                var role = new GetRoleDto { Id = roleEntity.Id, Name = roleEntity.Name, NormalizedName = roleEntity.NormalizedName };
                return ServiceResponse<GetRoleDto>.Succeeded(role, "Role created successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetRoleDto>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetRoleDto>> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            try
            {
                var roleEntity = await roleManager.FindByIdAsync(updateRoleDto.Id.ToString());
                if (roleEntity == null)
                    return ServiceResponse<GetRoleDto>.NotFound(null, "Role not found!");

                roleEntity.Name = updateRoleDto.Name.Trim();
                roleEntity.NormalizedName = updateRoleDto.Name.ToUpper().Trim();

                var result = await roleManager.UpdateAsync(roleEntity);
                if (!result.Succeeded)
                    return ServiceResponse<GetRoleDto>.Failed(null, GetErrors(result));

                var role = new GetRoleDto { Id = roleEntity.Id, Name = roleEntity.Name, NormalizedName = roleEntity.NormalizedName };
                return ServiceResponse<GetRoleDto>.Succeeded(role, "Role updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetRoleDto>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<bool>> CreateRoleClaims(int roleId, string[] auth)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(roleId.ToString());
                var claims = await roleManager.GetClaimsAsync(role);

                if(role == null)
                    return ServiceResponse<bool>.NotFound(false, "Role not found!");

                if(claims != null && claims.Count > 0)
                {
                    foreach( var claim in claims)
                    {
                        await roleManager.RemoveClaimAsync(role, claim);
                    }
                }

                foreach (var item in auth)
                {
                    await roleManager.AddClaimAsync(role, new Claim("AUTH_ACCESS", item));
                }
                return ServiceResponse<bool>.Succeeded(true, "Role claims updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<bool>.Failed(false, ex.Message);
            }
        }

        public async Task<ServiceResponse<List<string>>> GetRoleAuthorizations(int roleId)
        {
            try
            {
                List<string> auths = new List<string>();

                var role = await roleManager.FindByIdAsync(roleId.ToString());
                if(role == null)
                    return ServiceResponse<List<string>>.NotFound(null, "Role not found!");

                var claims = await roleManager.GetClaimsAsync(role);
                if(claims != null && claims.Count > 0)
                {
                    foreach (var claim in claims)
                    {
                        auths.Add(claim.Value);
                    }
                }
                return ServiceResponse<List<string>>.Succeeded(auths, "Role claims retrieved successfully.");

            }
            catch (Exception ex)
            {
                return ServiceResponse<List<string>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetUserDTO>> ChangeUserLock(int userId)
        {
            try
            {
                var user = await userManager.FindByIdAsync(userId.ToString());
                if (user == null)
                    return ServiceResponse<GetUserDTO>.NotFound(null, "User not found!");

                user.Locked = !user.Locked;
                var result = await userManager.UpdateAsync(user);

                if (!result.Succeeded)
                    return ServiceResponse<GetUserDTO>.Failed(null, "User update failed!");
                
                return ServiceResponse<GetUserDTO>.Succeeded(mapper.Map<GetUserDTO>(user), "User updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetUserDTO>.Failed(null, "User update failed!");
            }
        }

        private string GetErrors(IdentityResult result)
        {
            string errors = "";
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    errors += error.Description + "\n";
                }
            }
            return errors;
        }

    }
}
