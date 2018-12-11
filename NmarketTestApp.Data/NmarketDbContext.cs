using Microsoft.EntityFrameworkCore;
using NmarketTestApp.Models;

namespace NmarketTestApp.Data
{
    public class NmarketDbContext : DbContext
    {
        public NmarketDbContext():base()
        {
        }

        public NmarketDbContext(DbContextOptions<NmarketDbContext> options) : base(options) { }
        public DbSet<Building> Building { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Flat> Flat { get; set; }
        public DbSet<Region> Region { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>()
                .HasAlternateKey(r => r.RegionId);
            modelBuilder.Entity<Region>()
                .HasMany(d => d.Districts);
            modelBuilder.Entity<Region>()
                .HasIndex(b => b.RegionId)
                .IsUnique()
                .HasName("Index_RegionId");

            modelBuilder.Entity<District>()
                .HasAlternateKey(d => d.DistrictId);
            modelBuilder.Entity<District>()
                .HasOne(p => p.Region)
                .WithMany(d => d.Districts)
                .HasForeignKey(r => r.RegionId);
            modelBuilder.Entity<District>()
                .HasIndex(d => d.DistrictId)
                .IsUnique()
                .HasName("Index_DistrictId");

            modelBuilder.Entity<Building>()
                .HasAlternateKey(b => b.BuildingId);
            modelBuilder.Entity<Building>()
                .HasOne(d => d.District)
                .WithMany(b => b.Buildings)
                .HasForeignKey(r => r.DistrictId);
            modelBuilder.Entity<Building>()
                .HasIndex(b => b.BuildingId)
                .IsUnique()
                .HasName("Index_BuildingId");

            modelBuilder.Entity<Flat>()
                .HasAlternateKey(f => f.FlatId);
            modelBuilder.Entity<Flat>()
                .HasOne(b => b.Building)
                .WithMany(f => f.Flats)
                .HasForeignKey(r => r.BuildingId);
            modelBuilder.Entity<Flat>()
                .HasIndex(f => f.FlatId)
                .IsUnique()
                .HasName("Index_FlatId");
        }
    }
}

