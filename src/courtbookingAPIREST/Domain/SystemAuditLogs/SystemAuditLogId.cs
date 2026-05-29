public readonly record struct SystemAuditLogId(Guid Value)
{
    public static SystemAuditLogId New() => new(Guid.NewGuid());
    public static SystemAuditLogId From(Guid value) => new(value);
    public override string ToString() => Value.ToString();
}