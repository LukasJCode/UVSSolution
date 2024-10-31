using UVSSolution.Controllers;
using UVSSolution.Interfaces;
using UVSSolution.Models;
using UVSSolution.Repositories;
using UVSSolution.Utilities;

namespace UVSSolution
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if(args.Length < 2)
            {
                Console.WriteLine("Invalid arguments");
                return;
            }
            //Setting up application components
            AppDbContext db = new AppDbContext();
            IEmployeeRepository employeeRepositry = new EmployeeRepository(db);
            IEmployeeController employeeController = new EmployeeController(employeeRepositry);

            //Handling Commands and Options
            var command = Handlers.CommandHandler(args);
            var options = Handlers.OptionsHandler(args);

            //Based on given command executing corresponding code
            switch(command)
            {
                case "get-employee":
                    {
                        //Spliting options string array on symbol '=' to isolate integer that corresponds to employee id
                        int employeeId = int.Parse(options[0].Split('=')[1]);
                        await employeeController.GetEmployee(employeeId);
                    }
                    break;
                case "set-employee":
                    {
                        //Spliting options string array on symbol '=' to isolate employeeId, employeeName, employeeSalary
                        int employeeId = int.Parse(options[0].Split('=')[1]);
                        string employeeName = options[1].Split('=')[1];
                        decimal employeeSalary = int.Parse(options[2].Split('=')[1]);
                        var employee = new Employee { Id = employeeId, Name = employeeName, Salary = employeeSalary };
                        await employeeController.SetEmployee(employee);
                    }
                    break;
                default: Console.WriteLine("Invalid Command");
                    break;
            }
        }
    }
}
