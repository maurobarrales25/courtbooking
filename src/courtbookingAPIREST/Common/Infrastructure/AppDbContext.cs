using courtbookingAPIREST.Domain.AdminsClubs;
using courtbookingAPIREST.Domain.Clubs;
using courtbookingAPIREST.Domain.Courts;
using courtbookingAPIREST.Domain.SystemAuditLogs;
using Microsoft.EntityFrameworkCore;

namespace courtbookingAPIREST.Common.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Club> Clubs => Set<Club>();
    public DbSet<Court> Courts => Set<Court>();
    public DbSet<CourtTimeSlot> CourtTimeSlots => Set<CourtTimeSlot>();
    public DbSet<AdminClub> AdminsClubs => Set<AdminClub>();
    public DbSet<SystemAuditLog> SystemAuditLogs => Set<SystemAuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
