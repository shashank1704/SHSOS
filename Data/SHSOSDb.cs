using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using SHSOS.Models;
namespace SHSOS.Data
{
    public class SHSOSDb:DbContext
    {
        public SHSOSDb(DbContextOptions<SHSOSDb> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("shsos");
        }
        public DbSet<Hospitals> Hospital { get; set; }

        public DbSet<Departments> Department { get; set; }

        public DbSet<WaterConsumption> WaterConsumption { get; set; }

        public DbSet<EnergyConsumption> EnergyConsumption { get; set; }

        public DbSet<WasteManagement> WasteManagement { get; set; }

    }
   
}
