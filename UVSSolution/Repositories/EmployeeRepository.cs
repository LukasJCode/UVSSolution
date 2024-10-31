using Microsoft.EntityFrameworkCore;
using UVSSolution.Interfaces;
using UVSSolution.Models;

namespace UVSSolution.Repositories
{
    internal class EmployeeRepository : IEmployeeRepository
    {

        private readonly AppDbContext _db;

        public EmployeeRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await _db.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _db.Employees.Update(employee);
            await _db.SaveChangesAsync();
        }
    }
}
