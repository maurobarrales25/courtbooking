using courtbookingAPIREST.Domain.SystemAuditLogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace courtbookingAPIREST.Common.Infrastructure.Configurations.SystemAuditLogs;
public class SystemAuditLogConfiguration : IEntityTypeConfiguration<SystemAuditLog>
{
    public void Configure(EntityTypeBuilder<SystemAuditLog> builder)
    {
        builder.ToTable("system_audit_log");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .HasConversion(id => id.Value, v => SystemAuditLogId.From(v))
            .HasColumnName("log_id");

        builder.Property(s => s.ActorId)
            .HasColumnName("actor_id");

        builder.Property(s => s.ActorType)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnName("actor_type");

        builder.Property(s => s.EntityType)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnName("entity_type");

        builder.Property(s => s.EntityId)
            .HasColumnName("entity_id");

        builder.Property(s => s.Action)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("action");

        builder.Property(s => s.Reason)
            .HasColumnName("reason");

        builder.Property(s => s.CreatedAtUtc)
            .HasColumnName("created_at_utc");

        builder.Property(s => s.Metadata)
            .HasColumnName("metadata");
    }
}