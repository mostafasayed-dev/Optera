using Optera.Identity.DTOs;
using Optera.Identity.JWT;
using Optera.Shared.Pagination.Pagination;
using Optera.Shared.Response;

namespace Optera.Identity.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<ServiceResponse<JwtToken>> Register(RegisterDto registerDto);
        public Task<ServiceResponse<JwtToken>> Login(LoginDto loginDto);
        public Task<ServiceResponse<PagedList<GetUserDto>>> GetUsers(UserParams? userParams);
        public Task<ServiceResponse<GetUserDto>> GetUserById(string id);
        public Task<ServiceResponse<PagedList<GetRoleDto>>> GetRoles(UserParams? userParams);
        public Task<ServiceResponse<List<GetRoleListDto>>> GetRolesItemsList();
        public Task<ServiceResponse<GetRoleDto>> CreateRole(CreateRoleDto createRoleDto);
        public Task<ServiceResponse<GetRoleDto>> UpdateRole(UpdateRoleDto updateRoleDto);
        public Task<ServiceResponse<bool>> CreateRolePermissions(string roleId, string[] auths);
        public Task<ServiceResponse<List<string>>> GetRolePermissions(string roleId);
    }
}
