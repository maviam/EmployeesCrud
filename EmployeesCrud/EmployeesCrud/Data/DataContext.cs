using EmployeesCrud.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeesCrud.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) 
        { 
        
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
