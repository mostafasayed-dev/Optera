namespace Optera.Tasks.Models
{
    public class Task
    {
        public long Id { get; set; }
        public required string WorkflowInstanceId { get; set; }
        public required string WorkflowDefinitionId { get; set; }
        public string? TenantId { get; set; }
        public required string WorkflowName { get; set; }
        public string? CorrelationId { get; set; }
        public required string WorkflowTaskId { get; set; }
        public required string WorkflowTaskName { get; set; }
        public string? Payload { get; set; }
        public string? Result { get; set; }
        public bool IsCompleted { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? CompletedAt { get; set; }
    }
}
