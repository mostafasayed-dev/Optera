using Microsoft.AspNetCore.Identity;
using Optera.Identity.DTOs;
using Optera.Identity.JWT;
using System.Security.Claims;

namespace Optera.Identity.Repositories.Interfaces
{
    public interface IAuthRepository<TUser, TRole>
    {
        public Task<(IdentityResult Result, TUser? User)> CreateUserAsync(string username, string email, string phoneNumber, string password);
        public Task<IdentityResult> DeleteUserAsync(TUser user);
        public Task<IdentityResult> AddUserToRolesAsync(TUser user, List<string> roles);
        public Task<IdentityResult> AddUserClaimsAsync(TUser user);
        public Task<IList<Claim>> GetUserClaimsAsync(TUser user);
        public Task<TUser> GetUserByUsernameAsync(string username);
        public Task<bool> CheckUserPasswordAsync(TUser user, string password);
        public Task<IList<string>> GetUserRolesAsync(TUser user);
        public Task<TRole> GetRoleByNameAsync(string roleName);
        public Task<TRole> GetRoleByIdAsync(string id);
        public Task<IList<Claim>> GetRoleClaimsAsync(TRole role);
        public IQueryable<TUser> GetUsers();
        public IQueryable<TRole> GetRoles();
        public Task<(IdentityResult Result, TRole? Role)> CreateRoleAsync(string roleName);
        public Task<(IdentityResult Result, TRole? Role)> UpdateRoleAsync(TRole role);
        public Task<IdentityResult> RemoveRoleClaimAsync(TRole role, Claim claim);
        public Task<IdentityResult> AddRoleClaimAsync(TRole role, Claim claim);

        public Task<int> SaveChangesAsync();
    }
}
