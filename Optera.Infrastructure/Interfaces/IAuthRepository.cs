using Optera.DTOs.Role;
using Optera.DTOs.User;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Interfaces
{
    public interface IAuthRepository
    {
        public Task<ServiceResponse<Token>> Login(LoginDTO loginDto);
        public Task<ServiceResponse<Token>> Register(RegisterDTO registerDto);
        public Task<ServiceResponse<PagedList<GetUserDTO>>> GetUsers(UserParams? userParams);
        public Task<ServiceResponse<PagedList<GetRoleDto>>> GetRoles(UserParams? userParams);
        public Task<ServiceResponse<GetRoleDto>> CreateRole(CreateRoleDto createRoleDto);
        public Task<ServiceResponse<GetRoleDto>> UpdateRole(UpdateRoleDto updateRoleDto);
        public Task<ServiceResponse<bool>> CreateRoleClaims(int roleId, string[] auth);
        public Task<ServiceResponse<List<string>>> GetRoleAuthorizations(int roleId);
        public Task<ServiceResponse<ICollection<GetRoleListDto>>> GetRolesItemsList();
        public Task<ServiceResponse<GetUserDTO>> ChangeUserLock(int userId);
        public Task<ServiceResponse<RegisterDTO>> GetUserById(int id);
        public Task<ServiceResponse<bool>> ResetPassword(ResetPasswordDto resetPasswordDto);
    }
}
