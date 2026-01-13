using System.Text.Json;

namespace Optera.Events;

public record WebhookEvent(
    string EventType,
    RunTaskWebhook Payload,
    DateTimeOffset Timestamp
);

public record RunTaskWebhook(
    string WorkflowInstanceId,
    string WorkflowDefinitionId,
    string? TenantId,
    string WorkflowName,
    string CorrelationId,
    string TaskId,
    string TaskName,
    JsonElement TaskPayload
);

//public record TaskPayload(
//    List<string> Actors,
//    string Comment
//);