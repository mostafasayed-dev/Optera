using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Optera.Tasks.Services.Interfaces;
using System.Text.Json;

namespace Optera.Tasks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly IElsaClient elsaClient;

        public TasksController(AppDbContext dbContext, IElsaClient elsaClient)
        {
            this.dbContext = dbContext;
            this.elsaClient = elsaClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await dbContext.Tasks.Where(x => !x.IsCompleted).ToListAsync();
            return Ok(tasks);
        }

        [HttpPost("complete/{taskId}")]
        public async Task<IActionResult> CompleteTask(int taskId, [FromBody] object result)
        {
            var task = dbContext.Tasks.FirstOrDefault(x => x.Id == taskId);

            if (task == null)
                return NotFound("Task not found!");

            await elsaClient.ReportTaskCompletedAsync(task.WorkflowTaskId, result);

            task.IsCompleted = true;
            task.CompletedAt = DateTimeOffset.Now;
            if (result != null)
            {
                string jsonResult = JsonSerializer.Serialize(result);
                task.Result = jsonResult;
            }

            dbContext.Tasks.Update(task);
            await dbContext.SaveChangesAsync();

            return Ok(task);
        }
    }
}
