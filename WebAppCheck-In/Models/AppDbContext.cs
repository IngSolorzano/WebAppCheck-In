using Microsoft.EntityFrameworkCore;

namespace WebAppCheck_In.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options )
        {

        }
        //Models
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TimeRecord> TimeRecords { get; set; }
    }
}
