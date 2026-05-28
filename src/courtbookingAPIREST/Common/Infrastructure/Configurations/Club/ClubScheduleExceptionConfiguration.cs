using courtbookingAPIREST.Domain.Clubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace courtbookingAPIREST.Common.Infrastructure.Configurations;

public class ClubScheduleExceptionConfiguration : IEntityTypeConfiguration<ClubScheduleException>
{
    public void Configure(EntityTypeBuilder<ClubScheduleException> builder)
    {
        builder.ToTable("club_schedule_exceptions");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasConversion(id => id.Value, v => ClubScheduleExceptionID.From(v))
            .HasColumnName("club_schedule_exceptions_id");

        builder.Property(e => e.Date).HasColumnName("date").IsRequired();
        builder.Property(e => e.Reason).HasMaxLength(500).HasColumnName("reason").IsRequired();
        builder.Property(e => e.IsClosed).HasColumnName("is_closed").IsRequired();
        builder.Property(e => e.OpeningTime).HasColumnName("opening_time");
        builder.Property(e => e.ClosingTime).HasColumnName("closing_time");
    }
}
