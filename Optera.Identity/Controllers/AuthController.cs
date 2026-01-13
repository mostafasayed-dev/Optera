using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Optera.Identity.DTOs;
using Optera.Identity.Services.Interfaces;
using Optera.Shared.Pagination.Extensions;
using Optera.Shared.Pagination.Pagination;
using Optera.Shared.Response;

namespace Optera.Identity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AuthController : Controller
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<ServiceResponse<string>>> Register(RegisterDto registerDto)
        {
            var result = await authService.Register(registerDto);
            if(result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<ServiceResponse<string>>> Login(LoginDto loginDto)
        {
            var result = await authService.Login(loginDto);
            if (result.Success)
                return Ok(result);
            else
            {
                if (result.Status == ResponseStatus.NOT_AUTHORIZED)
                    return Unauthorized(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("token")]
        [AllowAnonymous]
        public async Task<ActionResult> GetToken(LoginDto loginDto)
        {
            var result = await authService.Login(loginDto);

            if (!result.Success)
                return BadRequest("Invalid username or password");

            return Ok(new
            {
                access_token = result.Result.JWT
            });
        }

        [HttpGet("users")]
        public async Task<ActionResult<ServiceResponse<PagedList<GetUserDto>>>> GetUsers([FromQuery] UserParams? userParams)
        {
            var result = await authService.GetUsers(userParams);
            if (result.Status == ResponseStatus.SUCCEEDED)
            {
                Response.AddPaginationHeader(result.Result.CurrentPage, result.Result.PageSize,
                                             result.Result.TotalCount, result.Result.TotalPages);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetUserById(string id)
        {
            var result = await authService.GetUserById(id);
            if (result.Status == ResponseStatus.SUCCEEDED)
                return Ok(result);
            else if (result.Status == ResponseStatus.NOT_FOUND)
                return NotFound(result);
            return BadRequest(result);
        }

        [HttpGet("roles")]
        public async Task<ActionResult<ServiceResponse<PagedList<GetRoleDto>>>> GetRoles([FromQuery] UserParams? userParams)
        {
            var result = await authService.GetRoles(userParams);
            if (result.Status == ResponseStatus.SUCCEEDED)
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
            var result = await authService.GetRolesItemsList();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("role")]
        public async Task<ActionResult<ServiceResponse<GetRoleDto>>> CreateRole(CreateRoleDto createRoleDto)
        {
            var result = await authService.CreateRole(createRoleDto);
            if (result.Status == ResponseStatus.SUCCEEDED)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("role")]
        public async Task<ActionResult<ServiceResponse<GetRoleDto>>> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            var result = await authService.UpdateRole(updateRoleDto);
            if (result.Status == ResponseStatus.SUCCEEDED)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("permissions/{roleId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> CreateRolePermission(string roleId, [FromBody] string[] auth)
        {
            var result = await authService.CreateRolePermissions(roleId, auth);
            if (result.Status == ResponseStatus.SUCCEEDED)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
