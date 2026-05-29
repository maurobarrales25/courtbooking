namespace courtbookingAPIREST.Domain.SystemAuditLogs;

public class SystemAuditLog
{
    public SystemAuditLogId Id { get; private set; }
    public Guid ActorId { get; private set; }
    public string ActorType { get; private set; }   // "admin_club" | "super_admin"
    public string EntityType { get; private set; }  // "club" | "admin_club"
    public Guid EntityId { get; private set; }
    public string Action { get; private set; }
    public string? Reason { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }
    public string? Metadata { get; private set; }

    private SystemAuditLog() { }

    public static SystemAuditLog Create(Guid actorId, string actorType,
        string entityType, Guid entityId, string action, string? reason = null, string? metadata = null) => new()
    {
        Id = SystemAuditLogId.New(),
        ActorId = actorId,
        ActorType = actorType,
        EntityType = entityType,
        EntityId = entityId,
        Action = action,
        Reason = reason,
        CreatedAtUtc = DateTime.UtcNow,
        Metadata = metadata
    };
}