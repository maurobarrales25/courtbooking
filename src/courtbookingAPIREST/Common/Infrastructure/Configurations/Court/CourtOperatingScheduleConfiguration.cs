using courtbookingAPIREST.Domain.Courts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace courtbookingAPIREST.Common.Infrastructure.Configurations;

public class CourtOperatingScheduleConfiguration : IEntityTypeConfiguration<CourtOperatingSchedule>
{
    public void Configure(EntityTypeBuilder<CourtOperatingSchedule> builder)
    {
        builder.ToTable("court_operating_schedules");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .HasConversion(id => id.Value, v => CourtOperatingScheduleID.From(v))
            .HasColumnName("court_operating_schedules_id");

        builder.Property(s => s.DayOfWeek)
            .HasConversion<string>()
            .HasColumnName("day_of_week")
            .IsRequired();

        builder.Property(s => s.OpeningTime).HasColumnName("opening_time").IsRequired();
        builder.Property(s => s.ClosingTime).HasColumnName("closing_time").IsRequired();
    }
}
