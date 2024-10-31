using UVSSolution.Interfaces;
using UVSSolution.Models;

namespace UVSSolution.Controllers
{
    internal class EmployeeController : IEmployeeController
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository) 
        {
            _employeeRepository = employeeRepository;
        }

        public async Task GetEmployee(int id)
        {
            if (id >= 0)
            {
                try
                {
                    Employee employee = await _employeeRepository.GetEmployeeAsync(id);
                    if (employee != null)
                    {
                        Console.WriteLine($"Employee Id: {employee.Id} Employee Name: {employee.Name} Employee Salary: {employee.Salary}");
                    }
                    else
                    {
                        Console.WriteLine("Employee with given id not found");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving employee: {ex.Message}");
                }

            }
            
        }

        public async Task SetEmployee(Employee employee)
        {
            try
            {
                Employee emp = await _employeeRepository.GetEmployeeAsync(employee.Id);

                if (emp == null)
                {
                    //Employee with given values doesnt exist so we create a new employee
                    await _employeeRepository.CreateEmployeeAsync(employee);
                    Console.WriteLine("Employee Created");
                    Console.WriteLine($"Employee Id: {employee.Id} Employee Name: {employee.Name} Employee Salary: {employee.Salary}");

                }
                else
                {
                    //Employee with given id exists so we update the properties
                    emp.Name = employee.Name;
                    emp.Salary = employee.Salary;

                    await _employeeRepository.UpdateEmployeeAsync(emp);

                    Console.WriteLine("Employee Updated");
                    Console.WriteLine($"Employee Id: {employee.Id} Employee Name: {employee.Name} Employee Salary: {employee.Salary}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting employee: {ex.Message}");
            }
           
        }
    }
}
