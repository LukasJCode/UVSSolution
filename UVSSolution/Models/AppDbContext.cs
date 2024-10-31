using Microsoft.EntityFrameworkCore;
using UVSSolution.Utilities;


namespace UVSSolution.Models
{
    internal class AppDbContext:DbContext
    {

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Handlers.GetConnectionString());
        }
    }
}
