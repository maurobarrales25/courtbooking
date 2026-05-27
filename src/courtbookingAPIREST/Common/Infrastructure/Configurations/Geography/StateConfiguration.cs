using courtbookingAPIREST.Domain.Geography;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace courtbookingAPIREST.Common.Infrastructure.Configurations.Geography;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("states");

        builder.Property<int>("StateId")
            .HasColumnName("state_id")
            .ValueGeneratedNever();

        builder.HasKey("StateId");

        builder.Property(s => s.Name)
            .HasMaxLength(100)
            .HasColumnName("name")
            .IsRequired();
    }
}
