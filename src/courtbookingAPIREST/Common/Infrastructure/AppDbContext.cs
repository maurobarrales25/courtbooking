using courtbookingAPIREST.Domain.Clubs;
using courtbookingAPIREST.Domain.Courts;
using Microsoft.EntityFrameworkCore;

namespace courtbookingAPIREST.Common.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Club> Clubs => Set<Club>();
    public DbSet<Court> Courts => Set<Court>();
    public DbSet<CourtTimeSlot> CourtTimeSlots => Set<CourtTimeSlot>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
