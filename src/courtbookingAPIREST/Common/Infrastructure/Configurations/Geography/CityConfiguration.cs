using courtbookingAPIREST.Domain.Geography;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace courtbookingAPIREST.Common.Infrastructure.Configurations.Geography;
public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("cities");

        builder.Property<int>("CityId")
            .HasColumnName("city_id")
            .ValueGeneratedNever();

        builder.HasKey("CityId");

        builder.Property(c => c.Name)
            .HasMaxLength(100)
            .HasColumnName("name")
            .IsRequired();

        builder.HasOne(c => c.State)
            .WithMany()
            .HasForeignKey("state_id")
            .OnDelete(DeleteBehavior.Restrict);
    }
        
}
