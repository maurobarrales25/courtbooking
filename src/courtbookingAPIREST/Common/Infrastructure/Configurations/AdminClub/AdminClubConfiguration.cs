using courtbookingAPIREST.Domain.AdminsClubs;
using courtbookingAPIREST.Domain.Clubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace courtbookingAPIREST.Common.Infrastructure.Configurations.AdminsClubs;

public class AdminClubConfiguration : IEntityTypeConfiguration<AdminClub>
{
    public void Configure(EntityTypeBuilder<AdminClub> builder)
    {
        builder.ToTable("admins_clubs");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasConversion(id => id.Value, v => AdminClubId.From(v))
            .HasColumnName("admin_id");

        builder.Property(a => a.ClubId)
            .HasConversion(id => id.Value, v => ClubID.From(v))
            .HasColumnName("club_id")
            .IsRequired();

        builder.Property(a => a.AuthProviderId)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("auth_provider_id");

        builder.Property(a => a.AuthProvider)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("auth_provider");

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("name");

        builder.Property(a => a.Email)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("email");

        builder.Property(a => a.IsOwner)
            .HasColumnName("is_owner");

        builder.Property(a => a.Status)
            .HasConversion<string>()
            .HasMaxLength(20)
            .HasColumnName("status");

        builder.Property(a => a.CreatedAtUtc)
            .HasColumnName("created_at_utc");

        builder.Property(a => a.LastLoginAtUtc)
            .HasColumnName("last_login_at_utc");

        builder.Property(a => a.RemovedAt)
            .HasColumnName("removed_at");

        builder.Property(a => a.RemovedBy)
            .HasColumnName("removed_by");

        builder.Property(a => a.OwnershipTransferredAt)
            .HasColumnName("ownership_transferred_at");

        builder.Property(a => a.OwnershipTransferredTo)
            .HasColumnName("ownership_transferred_to");

        builder.Property(a => a.ApprovedAt)
            .HasColumnName("approved_at");

        builder.Property(a => a.ApprovedBy)
            .HasColumnName("approved_by");
    }
}