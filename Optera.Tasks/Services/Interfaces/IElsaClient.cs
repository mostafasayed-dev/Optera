namespace Optera.Tasks.Services.Interfaces
{
    public interface IElsaClient
    {
        public Task ReportTaskCompletedAsync(string taskId, object? result = default, CancellationToken cancellationToken = default);
    }
}
