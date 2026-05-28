using courtbookingAPIREST.Domain.Courts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourtEntity = courtbookingAPIREST.Domain.Courts.Court;

namespace courtbookingAPIREST.Common.Infrastructure.Configurations.Court;

public class CourtTimeSlotConfiguration : IEntityTypeConfiguration<CourtTimeSlot>
{
    public void Configure(EntityTypeBuilder<CourtTimeSlot> builder)
    {
        builder.ToTable("court_time_slots");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .HasConversion(id => id.Value, v => CourtTimeSlotID.From(v))
            .HasColumnName("court_time_slot_id");

        builder.Property(s => s.CourtId)
            .HasConversion(id => id.Value, v => CourtID.From(v))
            .HasColumnName("court_id")
            .IsRequired();

        builder.HasOne<CourtEntity>()
            .WithMany()
            .HasForeignKey(s => s.CourtId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(s => s.Date).HasColumnName("date").IsRequired();
        builder.Property(s => s.Start).HasColumnName("start").IsRequired();
        builder.Property(s => s.End).HasColumnName("end").IsRequired();

        builder.Property(s => s.Status)
            .HasConversion<string>()
            .HasColumnName("status")
            .IsRequired();

        builder.HasIndex(s => new { s.CourtId, s.Date });
    }
}
