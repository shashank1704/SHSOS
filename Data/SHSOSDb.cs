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
            // Additional model configuration can go here
        }
        DbSet<Hospitals> Hospital { get; set; }

        DbSet<Departments> Department { get; set; }

        DbSet<WaterConsumption> WaterConsumption { get; set; }





    }
   
}
