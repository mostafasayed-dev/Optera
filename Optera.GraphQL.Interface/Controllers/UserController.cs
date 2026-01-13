using Microsoft.AspNetCore.Mvc;
using Optera.GraphQL.Interface.Controllers.Base;
using Optera.GraphQL.Interface.Enums;
using Optera.GraphQL.Interface.Pagination;
using Optera.GraphQL.Interface.Response;
using Optera.GraphQL.Interface.Services.Interfaces;

namespace Optera.GraphQL.Interface.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IGraphQLClientService graphQLClientService;

        public UserController(IGraphQLClientService graphQLClientService)
        {
            this.graphQLClientService = graphQLClientService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<dynamic>>> GetUserById(string id)
        {
            var variables = new { id };

            var result = await graphQLClientService.ExecuteQueryAsync<dynamic>(Queries.GetUserById, variables);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<dynamic>>> GetUsers([FromQuery] UserParams? userParams)
        {
            var result = await graphQLClientService.ExecuteQueryAsync<dynamic>(Queries.GetUsers, null, userParams);

            return Ok(result);
        }
    }
}
