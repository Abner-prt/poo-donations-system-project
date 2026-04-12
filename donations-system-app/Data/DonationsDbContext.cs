using Microsoft.EntityFrameworkCore;
using donations_system_app.Entities;

namespace donations_system_app.Data;

public class DonationsDbContext : DbContext
{
    public DonationsDbContext(DbContextOptions<DonationsDbContext> options) : base(options)
    {
    }

    public DbSet<DonorEntity> Donors { get; set; }
    public DbSet<DonationEntity> Donations { get; set; }
    public DbSet<RequestEntity> Requests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configura la relacion 1 a muchos Un donante puede tener varias donaciones
        modelBuilder.Entity<DonationEntity>()
            .HasOne(d => d.Donor)
            .WithMany(u => u.Donations)
            .HasForeignKey(d => d.DonorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
