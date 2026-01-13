using Microsoft.AspNetCore.Mvc;
using Optera.GraphQL.Interface.Controllers.Base;
using Optera.GraphQL.Interface.Enums;
using Optera.GraphQL.Interface.Pagination;
using Optera.GraphQL.Interface.Response;
using Optera.GraphQL.Interface.Services.Interfaces;

namespace Optera.GraphQL.Interface.Controllers
{
    public class ConfigurationController : BaseApiController
    {
        private readonly IGraphQLClientService graphQLClientService;

        public ConfigurationController(IGraphQLClientService graphQLClientService)
        {
            this.graphQLClientService = graphQLClientService;
        }

        [HttpGet("components")]
        public async Task<ActionResult<ServiceResponse<dynamic>>> GetComponents([FromQuery] UserParams? userParams)
        {
            var result = await graphQLClientService.ExecuteQueryAsync<dynamic>(Queries.GetComponents, null, userParams);
            return Ok(result);
        }
    }
}
