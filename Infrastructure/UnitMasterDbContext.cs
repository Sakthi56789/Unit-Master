using Microsoft.EntityFrameworkCore;
using UnitMasterSample.Domain.Models;
namespace UnitMasterSample.Infrastructure
{
    public class UnitMasterDbContext : DbContext 
    {
        public UnitMasterDbContext (DbContextOptions<UnitMasterDbContext> options ) : base( options )
        {

        }

        public DbSet<UnitMaster> unitmaster { get; set; }  
    }
}
