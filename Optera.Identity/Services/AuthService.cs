using AutoMapper;
using AutoMapper.QueryableExtensions;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Optera.Identity.DTOs;
using Optera.Identity.JWT;
using Optera.Identity.Models;
using Optera.Identity.Repositories.Interfaces;
using Optera.Identity.Services.Interfaces;
using Optera.Shared.Core.Identity;
using Optera.Shared.Identity;
using Optera.Shared.Messaging.Events.Users;
using Optera.Shared.Pagination.Pagination;
using Optera.Shared.Response;
using System.Security.Claims;

namespace Optera.Identity.Services
{
    public class AuthService<TUser, TRole> : IAuthService
            where TUser : User
            where TRole : Role
    {
        private readonly IAuthRepository<TUser, TRole> authRepository;
        private readonly IJwtTokenService jwtTokenService;
        private readonly ILogger<AuthService<TUser, TRole>> logger;
        private readonly IMapper mapper;
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ICurrentUserContext currentUserContext;

        public AuthService(IAuthRepository<TUser, TRole> authRepository,
                                     IJwtTokenService jwtTokenService,
                                     ILogger<AuthService<TUser, TRole>> logger,
                                     IMapper mapper,
                                     IPublishEndpoint publishEndpoint,
                                     ICurrentUserContext currentUserContext
                                    )
        {
            this.authRepository = authRepository;
            this.jwtTokenService = jwtTokenService;
            this.logger = logger;
            this.mapper = mapper;
            this.publishEndpoint = publishEndpoint;
            this.currentUserContext = currentUserContext;
        }

        public async Task<ServiceResponse<JwtToken>> Register(RegisterDto registerDto)
        {
            try
            {
                // user creation
                var userResult = await authRepository.CreateUserAsync(registerDto.Username, registerDto.Email, registerDto.PhoneNumber, registerDto.Password);
                if (userResult.User == null)
                {
                    logger.LogWarning("Registration failed for {Username}: {Errors}",
                            registerDto.Username,
                            string.Join(", ", userResult.Result.Errors.Select(e => e.Description)));
                    return ServiceResponse<JwtToken>.Failed(null, GetErrors(userResult.Result));
                }

                // roles assignment
                var rolesResult = await authRepository.AddUserToRolesAsync(userResult.User, registerDto.Roles);
                if (!rolesResult.Succeeded)
                {
                    logger.LogWarning("Role assignment failed for {Username}. Roles: {Roles}. Errors: {Errors}",
                                        userResult.User.UserName,
                      string.Join(", ", registerDto.Roles),
                      string.Join(", ", rolesResult.Errors.Select(e => e.Description)));

                    await authRepository.DeleteUserAsync(userResult.User);

                    return ServiceResponse<JwtToken>.Failed(null, GetErrors(rolesResult));
                }

                // claims creation
                var claimsResult = await authRepository.AddUserClaimsAsync(userResult.User);
                if (!claimsResult.Succeeded)
                {
                    logger.LogWarning("Claim assignment failed for {Username}. Errors: {Errors}",
                                        userResult.User.UserName,
                      string.Join(", ", claimsResult.Errors.Select(e => e.Description)));
                    return ServiceResponse<JwtToken>.Failed(null, GetErrors(claimsResult));
                }

                // token generation
                var claims = await authRepository.GetUserClaimsAsync(userResult.User);
                var token = jwtTokenService.GenerateJwtToken(claims);
                token.UserId = userResult.User.Id;

                logger.LogInformation("User {Username} registered successfully with Id {UserId}",
                            userResult.User.UserName, userResult.User.Id);

                var @event = new UserRegistered(
                        userResult.User.Id,
                        userResult.User.UserName!,
                        userResult.User.NormalizedUserName!,
                        userResult.User.Email!,
                        userResult.User.NormalizedEmail!,
                        userResult.User.EmailConfirmed!,
                        userResult.User.PhoneNumber!,
                        userResult.User.PhoneNumberConfirmed!
                        )
                {
                    Username = currentUserContext.UserName!
                };

                await publishEndpoint.Publish(@event);

                await authRepository.SaveChangesAsync();

                return ServiceResponse<JwtToken>.Succeeded(token, "User created successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error while registering user {Username}", registerDto.Username);
                return ServiceResponse<JwtToken>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<JwtToken>> Login(LoginDto loginDto)
        {
            try
            {
                var user = await authRepository.GetUserByUsernameAsync(loginDto.Email);
                if (user == null)
                {
                    logger.LogInformation("Invalid Username or Password | Username: {username}",
                        loginDto.Email);
                    return ServiceResponse<JwtToken>.NotAuthorized(null, "Invalid Username or Password.");
                }

                if (!await authRepository.CheckUserPasswordAsync(user, loginDto.Password))
                {
                    logger.LogInformation("Invalid Username or Password | Username: {username}",
                        loginDto.Email);
                    return ServiceResponse<JwtToken>.NotAuthorized(null, "Invalid Username or Password.");
                }

                var claims = new List<Claim>();
                var userClaims = await authRepository.GetUserClaimsAsync(user);
                var roles = await authRepository.GetUserRolesAsync(user);
                claims.AddRange(userClaims);

                foreach (var roleName in roles)
                {
                    var role = await authRepository.GetRoleByNameAsync(roleName);
                    var roleClaims = await authRepository.GetRoleClaimsAsync(role);
                    claims.AddRange(roleClaims);
                }

                var token = jwtTokenService.GenerateJwtToken(claims);
                token.UserId = user.Id;

                logger.LogInformation("User {Username} logged in successfully with Id {UserId}",
                        user.UserName, user.Id);

                await publishEndpoint.Publish(new UserLoggedInEvent(
                    user.Id,
                    user.UserName!,
                    user.Email!));

                return ServiceResponse<JwtToken>.Succeeded(token, "User Logged in successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error while login user {Username} !", loginDto.Email);
                return ServiceResponse<JwtToken>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<PagedList<GetUserDto>>> GetUsers(UserParams? userParams)
        {
            try
            {
                var result = authRepository.GetUsers()
                    .ProjectTo<GetUserDto>(mapper.ConfigurationProvider);

                var list = await PagedList<GetUserDto>.CreatePageAsync(result, userParams);

                return ServiceResponse<PagedList<GetUserDto>>.Succeeded(list, "Users retrieved successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error while retrieving users!");
                return ServiceResponse<PagedList<GetUserDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserById(long id)
        {
            try
            {
                var result = await authRepository.GetUsers()
                    .Where(x => x.Id == id)
                    .ProjectTo<GetUserDto>(mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

                if (result == null)
                    return ServiceResponse<GetUserDto>.NotFound(null, "User not found!.");
                return ServiceResponse<GetUserDto>.Succeeded(result, "User retrieved successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Unexpected error while retrieving user by id { id } !");
                return ServiceResponse<GetUserDto>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<PagedList<GetRoleDto>>> GetRoles(UserParams? userParams)
        {
            try
            {
                var result = authRepository.GetRoles()
                    .Where(x => x.NormalizedName != "ADMIN")
                    .ProjectTo<GetRoleDto>(mapper.ConfigurationProvider);

                var list = await PagedList<GetRoleDto>.CreatePageAsync(result, userParams);

                return ServiceResponse<PagedList<GetRoleDto>>.Succeeded(list, "Roles retrieved successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error while retrieving roles!");
                return ServiceResponse<PagedList<GetRoleDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<List<GetRoleListDto>>> GetRolesItemsList()
        {
            try
            {
                var result = await authRepository.GetRoles()
                    .Where(p => p.Name.ToUpper().Trim() != "ADMIN")
                    .ProjectTo<GetRoleListDto>(mapper.ConfigurationProvider)
                    .ToListAsync();

                return ServiceResponse<List<GetRoleListDto>>.Succeeded(result, "Roles list retrieved successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error while retrieving roles list!");
                return ServiceResponse<List<GetRoleListDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetRoleDto>> CreateRole(CreateRoleDto createRoleDto)
        {
            try
            {
                var result = await authRepository.CreateRoleAsync(createRoleDto.Name);
                if (!result.Result.Succeeded)
                {
                    logger.LogWarning("Role creation failed for {role}. Errors: {Errors}",
                        createRoleDto.Name,
                        string.Join(", ", result.Result.Errors.Select(e => e.Description)));
                    return ServiceResponse<GetRoleDto>.Failed(null, GetErrors(result.Result));
                }

                return ServiceResponse<GetRoleDto>.Succeeded(
                    new GetRoleDto { Id = result.Role.Id, Name = result.Role.Name, NormalizedName = result.Role.NormalizedName }, 
                    "Role created successfully.");

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error while creating role!");
                return ServiceResponse<GetRoleDto>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetRoleDto>> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            try
            {
                var role = await authRepository.GetRoleByIdAsync(updateRoleDto.Id);
                if (role == null)
                    return ServiceResponse<GetRoleDto>.NotFound(null, $"Role {updateRoleDto.Name} not found!");

                role.Name = updateRoleDto.Name;
                role.NormalizedName = updateRoleDto.Name.ToUpper().Trim();

                var result = await authRepository.UpdateRoleAsync(role);

                if(!result.Result.Succeeded)
                    return ServiceResponse<GetRoleDto>.Failed(null, GetErrors(result.Result));

                return ServiceResponse<GetRoleDto>.Succeeded(
                    new GetRoleDto { Id = result.Role.Id, Name = result.Role.Name, NormalizedName = result.Role.NormalizedName },
                    "Role updated successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error while updating role!");
                return ServiceResponse<GetRoleDto>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<bool>> CreateRolePermissions(string roleId, string[] auths)
        {
            try
            {
                var role = await authRepository.GetRoleByIdAsync(roleId);
                if (role == null)
                    return ServiceResponse<bool>.NotFound(false, "Role not found!");

                var claims = await authRepository.GetRoleClaimsAsync(role);
                foreach (var claim in claims)
                {
                    await authRepository.RemoveRoleClaimAsync(role, claim);
                }

                foreach (var auth in auths)
                {
                    await authRepository.AddRoleClaimAsync(role, new Claim("AUTH_ACCESS", auth));
                }

                return ServiceResponse<bool>.Succeeded(true, "Role permissions updated successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error while creating role permissions!");
                return ServiceResponse<bool>.Failed(false, ex.Message);
            }
        }

        public async Task<ServiceResponse<List<string>>> GetRolePermissions(string roleId)
        {
            try
            {
                List<string> auths = new List<string>();

                var role = await authRepository.GetRoleByIdAsync(roleId);
                if (role == null)
                    return ServiceResponse<List<string>>.NotFound(null, "Role not found!");

                var claims = await authRepository.GetRoleClaimsAsync(role);
                if (claims != null && claims.Count > 0)
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
                logger.LogError(ex, "Unexpected error while retrieving role claims!");
                return ServiceResponse<List<string>>.Failed(null, ex.Message);
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
