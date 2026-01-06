using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace SHSOS.Data
{
    public class SHSOSDb:DbContext
    {
        public SHSOSDb(DbContextOptions<SHSOSDb> options) : base(options)
        {
        }
      
    }
   
}
