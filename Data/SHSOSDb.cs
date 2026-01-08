using Microsoft.EntityFrameworkCore;
using SHSOS.Models;

namespace SHSOS.Data
{
    public class SHSOSDb : DbContext
    {
        public SHSOSDb(DbContextOptions<SHSOSDb> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Use the database schema in your SQL Server: "shsos"
            modelBuilder.HasDefaultSchema("shsos");

            // Explicit primary key configuration
            modelBuilder.Entity<Hospitals>().HasKey(h => h.HospitalID);
            modelBuilder.Entity<Departments>().HasKey(d => d.DepartmentID);
            modelBuilder.Entity<WaterConsumption>().HasKey(w => w.ConsumptionID);
            modelBuilder.Entity<EnergyConsumption>().HasKey(e => e.EnergyConsumptionID);
            modelBuilder.Entity<WasteManagement>().HasKey(wm => wm.WasteRecordID);

            // Map CLR entities to the exact table names and schema
            modelBuilder.Entity<Hospitals>().ToTable("Hospitals", "shsos");
            modelBuilder.Entity<Departments>().ToTable("Departments", "shsos");
            modelBuilder.Entity<WaterConsumption>().ToTable("WaterConsumption", "shsos");
            modelBuilder.Entity<EnergyConsumption>().ToTable("EnergyConsumption", "shsos");
            modelBuilder.Entity<WasteManagement>().ToTable("WasteManagement", "shsos");

            // Relationship: Departments -> Hospitals
            modelBuilder.Entity<Departments>()
                .HasOne<Hospitals>()
                .WithMany()
                .HasForeignKey(d => d.HospitalID)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Hospitals> Hospitals { get; set; }

        // Use plural DbSet name to match model and database table
        public DbSet<Departments> Departments { get; set; }

        public DbSet<WaterConsumption> WaterConsumption { get; set; }

        public DbSet<EnergyConsumption> EnergyConsumption { get; set; }

        public DbSet<WasteManagement> WasteManagement { get; set; }
    }
}
