using Microsoft.AspNetCore.Mvc;
using Optera.Events;
using Optera.Tasks.Models;

namespace Optera.Tasks.Controllers
{
    [ApiController]
    [Route("api/webhooks")]
    public class WebhookController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        public WebhookController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("run-task")]
        public async Task<IActionResult> RunTask([FromBody] WebhookEvent webhookEvent)
        {
            var task = new Optera.Tasks.Models.Task
            {
                WorkflowDefinitionId = webhookEvent.Payload.WorkflowDefinitionId,
                WorkflowInstanceId = webhookEvent.Payload.WorkflowInstanceId,
                TenantId = webhookEvent.Payload.TenantId,
                WorkflowName = webhookEvent.Payload.WorkflowName,
                CorrelationId = webhookEvent.Payload.CorrelationId,
                WorkflowTaskId = webhookEvent.Payload.TaskId,
                WorkflowTaskName = webhookEvent.Payload.TaskName,
                Payload = webhookEvent.Payload.TaskPayload.GetRawText(),
                CreatedAt = DateTimeOffset.Now
            };

            await dbContext.Tasks.AddAsync(task);
            await dbContext.SaveChangesAsync();

            return Ok(webhookEvent);
        }
    }
}
