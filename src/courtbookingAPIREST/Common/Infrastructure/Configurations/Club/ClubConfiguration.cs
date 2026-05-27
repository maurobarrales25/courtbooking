using courtbookingAPIREST.Domain.Clubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace courtbookingAPIREST.Common.Infrastructure.Configurations.Club;

public class ClubConfiguration : IEntityTypeConfiguration<Domain.Clubs.Club>
{
    public void Configure(EntityTypeBuilder<Domain.Clubs.Club> builder)
    {
        builder.ToTable("clubs");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasConversion(id => id.Value, v => ClubID.From(v))
            .HasColumnName("club_id");

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("name");

        builder.Property(c => c.Address)
            .IsRequired()
            .HasMaxLength(300)
            .HasColumnName("address");

        builder.OwnsOne(c => c.Location, loc =>
        {
            loc.Ignore(l => l.State);
            loc.Ignore(l => l.Neighborhood);

            loc.Property(l => l.City)
                .HasMaxLength(100)
                .HasColumnName("city")
                .IsRequired();
        });

        builder.HasMany(c => c.Schedules)
            .WithOne()
            .HasForeignKey("club_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.ScheduleExceptions)
            .WithOne()
            .HasForeignKey("club_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
