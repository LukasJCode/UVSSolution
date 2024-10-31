using UVSSolution.Models;

namespace UVSSolution.Interfaces
{
    internal interface IEmployeeController
    {
        public Task GetEmployee(int id);
        public Task SetEmployee(Employee employee);
    }
}
