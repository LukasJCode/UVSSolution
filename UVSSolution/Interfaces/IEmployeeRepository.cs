using UVSSolution.Models;

namespace UVSSolution.Interfaces
{
    internal interface IEmployeeRepository
    {
        public Task CreateEmployeeAsync(Employee employee);
        public Task UpdateEmployeeAsync(Employee employee);
        public Task<Employee> GetEmployeeAsync(int id);
    }
}
