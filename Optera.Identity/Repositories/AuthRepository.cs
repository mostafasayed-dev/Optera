using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Optera.Identity.Models;
using Optera.Identity.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Optera.Identity.Repositories
{
    public class AuthRepository<TUser, TRole> : IAuthRepository<TUser, TRole>
            where TUser : User, new()
            where TRole : Role, new()
    {
        private readonly UserManager<TUser> userManager;
        private readonly RoleManager<TRole> roleManager;
        private readonly AppDbContext appDbContext;

        public AuthRepository(UserManager<TUser> userManager,
                              RoleManager<TRole> roleManager,
                              AppDbContext appDbContext)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.appDbContext = appDbContext;
        }

        public async Task<(IdentityResult Result, TUser? User)> CreateUserAsync(string username, string email, string phoneNumber, string password)
        {
            var newUser = new TUser
            {
                UserName = username,
                Email = email,
                PhoneNumber = phoneNumber,
            };

            var result = await userManager.CreateAsync(newUser, password);
            return (result, result.Succeeded ? newUser : null);
        }

        public async Task<IdentityResult> DeleteUserAsync(TUser user)
        {
            return await userManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> AddUserToRolesAsync(TUser user, List<string> roles)
        {
            var result = await userManager.AddToRolesAsync(user, roles);

            return result;
        }

        public async Task<IdentityResult> AddUserClaimsAsync(TUser user)
        {
            var claimsToAdd = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName!),
                new Claim("permissions", "*")
            };

            var result = await userManager.AddClaimsAsync(user, claimsToAdd);
            return result;
        }

        public async Task<IList<Claim>> GetUserClaimsAsync(TUser user)
        {
            return await userManager.GetClaimsAsync(user);
        }

        public async Task<TUser> GetUserByUsernameAsync(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            return user;
        }

        public async Task<bool> CheckUserPasswordAsync(TUser user, string password)
        {
            var result = await userManager.CheckPasswordAsync(user, password);
            return result;
        }

        public async Task<IList<string>> GetUserRolesAsync(TUser user)
        {
            return await userManager.GetRolesAsync(user);
        }

        public async Task<TRole> GetRoleByNameAsync(string roleName)
        {
            return await roleManager.FindByNameAsync(roleName);
        }

        public async Task<TRole> GetRoleByIdAsync(string id)
        {
            return await roleManager.FindByIdAsync(id);
        }

        public async Task<IList<Claim>> GetRoleClaimsAsync(TRole role)
        {
            return await roleManager.GetClaimsAsync(role);
        }

        public async Task<IdentityResult> RemoveRoleClaimAsync(TRole role, Claim claim)
        {
            return await roleManager.RemoveClaimAsync(role, claim);
        }

        public async Task<IdentityResult> AddRoleClaimAsync(TRole role, Claim claim)
        {
            return await roleManager.AddClaimAsync(role, claim);
        }

        public IQueryable<TUser> GetUsers()
        {
            return userManager.Users;
        }

        public IQueryable<TRole> GetRoles()
        {
            return roleManager.Roles.AsNoTracking();
        }

        public async Task<(IdentityResult Result, TRole? Role)> CreateRoleAsync(string roleName)
        {
            var newRole = new TRole
            {
                Name = roleName.Trim(),
                NormalizedName = roleName.ToUpper().Trim()
            };

            var result = await roleManager.CreateAsync(newRole);
            return (result, result.Succeeded ? newRole : null);
        }

        public async Task<(IdentityResult Result, TRole? Role)> UpdateRoleAsync(TRole role)
        {
            var result = await roleManager.UpdateAsync(role);
            return (result, result.Succeeded ? role : null);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await appDbContext.SaveChangesAsync();
        }
    }
}
