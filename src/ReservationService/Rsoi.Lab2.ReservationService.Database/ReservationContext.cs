using Microsoft.EntityFrameworkCore;

namespace Rsoi.Lab2.ReservationService.Database;

#nullable disable
public class ReservationContext : DbContext
{
    public DbSet<Reservation> Reservations { get; set; }

    public ReservationContext(DbContextOptions<ReservationContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ReservationConfiguration());
    }
}
#nullable restore