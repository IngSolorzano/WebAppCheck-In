using Microsoft.EntityFrameworkCore;
using WebAppCheck_In.Models;

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
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sale> Sales { get; set; }  
        public DbSet<SaleDetail> SaleDetails { get; set; }  
        public DbSet<User> Users { get; set; }
        public DbSet<WebAppCheck_In.Models.EmployeeType>? EmployeeType { get; set; }
    }
}
