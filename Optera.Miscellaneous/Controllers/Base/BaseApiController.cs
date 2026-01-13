using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Optera.Miscellaneous.Controllers.Base
{
    [Route("optera/api/miscellaneous/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseApiController : ControllerBase
    {

    }
}
