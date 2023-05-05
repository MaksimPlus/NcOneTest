using Microsoft.EntityFrameworkCore;
using NcOne.Models;

namespace NcOne.DAL
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    }
}
