using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Optera.Controllers.Base;
using Optera.DTOs.Core;
using Optera.DTOs.Country;
using Optera.DTOs.Role;
using Optera.DTOs.User;
using Optera.Extensions;
using Optera.Infrastructure.Interfaces;
using Optera.Models;
using Optera.Repositories;
using Optera.Utils.Models;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System.Threading.Tasks;

namespace Optera.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IAuthRepository authRepository;
        private readonly IAuthorizationRepository authorizationRepository;

        public AuthController(IAuthRepository authRepository, IAuthorizationRepository authorizationRepository)
        {
            this.authRepository = authRepository;
            this.authorizationRepository = authorizationRepository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<ServiceResponse<string>>> Register(RegisterDTO registerDto)
        {
            var result = await authRepository.Register(registerDto);
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<ActionResult<ServiceResponse<Token>>> Login(LoginDTO loginDto)
        {
            var result = await authRepository.Login(loginDto);

            if (result.Success)
                return Ok(result);

            return Unauthorized(result);
        }

        [HttpPost]
        [Route("logout")]
        public ActionResult<ServiceResponse<string>> Logout()
        {
            return Ok(ServiceResponse<string>.Succeeded("Logged out successfully."));
        }

        [AllowAnonymous]
        [HttpPost("reset-password")]
        public async Task<ActionResult<ServiceResponse<bool>>> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var result = await authRepository.ResetPassword(resetPasswordDto);

            if(result.Success)
                return Ok(result);

            return BadRequest(result);
        }



        [HttpGet("users")]
        public async Task<ActionResult<ServiceResponse<PagedList<GetUserDTO>>>> GetUsers([FromQuery] UserParams? userParams)
        {
            var result = await authRepository.GetUsers(userParams);
            if (result.Status == ServiceStatus.Succeeded)
            {
                Response.AddPaginationHeader(result.Result.CurrentPage, result.Result.PageSize,
                                             result.Result.TotalCount, result.Result.TotalPages);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<ServiceResponse<RegisterDTO>>> GetUserById(int id)
        {
            var result = await authRepository.GetUserById(id);
            if (result.Status == ServiceStatus.Succeeded)
                return Ok(result);
            else if(result.Status == ServiceStatus.NotFound)
                return NotFound(result);
            return BadRequest(result);
        }

        [HttpGet("roles")]
        public async Task<ActionResult<ServiceResponse<PagedList<GetRoleDto>>>> GetRoles([FromQuery] UserParams? userParams)
        {
            var result = await authRepository.GetRoles(userParams);
            if (result.Status == ServiceStatus.Succeeded)
            {
                Response.AddPaginationHeader(result.Result.CurrentPage, result.Result.PageSize,
                                             result.Result.TotalCount, result.Result.TotalPages);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("roles-items-list")]
        public async Task<ActionResult<ServiceResponse<ICollection<GetRoleListDto>>>> GetRolesList()
        {
            var result = await authRepository.GetRolesItemsList();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("role")]
        public async Task<ActionResult<ServiceResponse<GetRoleDto>>> CreateRole(CreateRoleDto createRoleDto)
        {
            var result = await authRepository.CreateRole(createRoleDto);
            if (result.Status == ServiceStatus.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("role")]
        public async Task<ActionResult<ServiceResponse<GetRoleDto>>> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            var result = await authRepository.UpdateRole(updateRoleDto);
            if (result.Status == ServiceStatus.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("authorizations")]
        public async Task<ActionResult<ServiceResponse<List<GetAuthorizationDto>>>> GetAuthorizations()
        {
            var result = await authorizationRepository.GetAuthorizations();
            if (result.Status == ServiceStatus.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("authorizations/{roleId}")]
        public async Task<ActionResult<ServiceResponse<List<string>>>> GetRoleAuthorizations(int roleId)
        {
            var result = await authRepository.GetRoleAuthorizations(roleId);
            if (result.Status == ServiceStatus.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("authorizations/{roleId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> CreateAuthorizations(int roleId, [FromBody] string[] auth)
        {
            var result = await authRepository.CreateRoleClaims(roleId, auth);
            if (result.Status == ServiceStatus.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("ChangeUserLock/{userId}")]
        public async Task<ActionResult<ServiceResponse<GetUserDTO>>> ChangeUserLock(int userId)
        {
            var result = await authRepository.ChangeUserLock(userId);
            if (result.Status == ServiceStatus.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
