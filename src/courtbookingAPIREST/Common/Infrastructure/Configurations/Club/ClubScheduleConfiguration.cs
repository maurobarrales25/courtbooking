using courtbookingAPIREST.Domain.Clubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace courtbookingAPIREST.Common.Infrastructure.Configurations;

public class ClubScheduleConfiguration : IEntityTypeConfiguration<ClubSchedule>
{
    public void Configure(EntityTypeBuilder<ClubSchedule> builder)
    {
        builder.ToTable("club_schedules");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .HasConversion(id => id.Value, v => ClubScheduleID.From(v))
            .HasColumnName("club_schedules_id");

        builder.Property(s => s.DayOfWeek)
            .HasConversion<string>()
            .HasColumnName("day_of_week")
            .IsRequired();

        builder.Property(s => s.OpeningTime).HasColumnName("opening_time").IsRequired();
        builder.Property(s => s.ClosingTime).HasColumnName("closing_time").IsRequired();
    }
}
