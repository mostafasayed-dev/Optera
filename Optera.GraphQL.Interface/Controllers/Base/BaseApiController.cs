using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Optera.GraphQL.Interface.Controllers.Base
{
    [Route("interface/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseApiController : ControllerBase
    {

    }
}
