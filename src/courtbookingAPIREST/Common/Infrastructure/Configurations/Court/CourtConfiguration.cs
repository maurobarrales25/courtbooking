using courtbookingAPIREST.Domain.Clubs;
using courtbookingAPIREST.Domain.Courts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourtEntity = courtbookingAPIREST.Domain.Courts.Court;

namespace courtbookingAPIREST.Common.Infrastructure.Configurations;

public class CourtConfiguration : IEntityTypeConfiguration<CourtEntity>
{
    public void Configure(EntityTypeBuilder<CourtEntity> builder)
    {
        builder.ToTable("courts");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasConversion(id => id.Value, v => CourtID.From(v))
            .HasColumnName("court_id");

        builder.Property(c => c.ClubId)
            .HasConversion(id => id.Value, v => ClubID.From(v))
            .HasColumnName("club_id")
            .IsRequired();

        builder.Property(c => c.Name)
            .HasMaxLength(150)
            .HasColumnName("name")
            .IsRequired();

        builder.Property(c => c.SlotDuration).HasColumnName("slot_duration").IsRequired();
        builder.Property(c => c.OverridesClub).HasColumnName("overrides_club").IsRequired();

        builder.HasMany(c => c.OperatingSchedules)
            .WithOne()
            .HasForeignKey("court_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
