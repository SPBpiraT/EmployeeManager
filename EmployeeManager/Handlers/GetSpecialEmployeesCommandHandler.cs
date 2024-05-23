using EmployeeManager.Data;
using EmployeeManager.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EmployeeManager.Handlers
{
    internal class GetSpecialEmployeesCommandHandler
    {
        private Stopwatch stopwatch = new Stopwatch();

        private readonly Func<EmployeesDbContext, IEnumerable<Employee>> GetEmployees =
        EF.CompileQuery(
            (EmployeesDbContext context) =>
                context.Employees
                .Where(e => e.Gender == Gender.Male && e.LastName.StartsWith("F")));

        public GetSpecialEmployeesCommandHandler() 
        {
            //HandleBefore();
            HandleAfter();
        }

        //Before.
        private void HandleBefore()
        {
            using (EmployeesDbContext db = new EmployeesDbContext())
            {
                stopwatch.Start();

                var employees = db.Employees
                                .Where(e => e.Gender == Gender.Male && e.LastName.StartsWith("F"))
                                .ToList();

                stopwatch.Stop();

                foreach (var employee in employees)
                {
                    Console.WriteLine("{0} {1} {2}, {3}, {4}", 
                                        employee.LastName, employee.FirstName, employee.MiddleName, employee.BirthDate, employee.Gender);
                }

                Console.WriteLine($"Time taken to execute the query: {stopwatch.ElapsedMilliseconds} milliseconds");


            }
        }
        //Avg time taken: 650ms

        //After
        private void HandleAfter()
        {
            using (EmployeesDbContext db = new EmployeesDbContext())
            {
                stopwatch.Start();

                var employees = GetEmployees(db);

                stopwatch.Stop();

                foreach (var employee in employees)
                {
                    Console.WriteLine("{0} {1} {2}, {3}, {4}", 
                                        employee.LastName, employee.FirstName, employee.MiddleName, employee.BirthDate, employee.Gender);
                }

                Console.WriteLine($"Time taken to execute the query: {stopwatch.ElapsedMilliseconds} milliseconds");


            }
        }
        //Avg time taken: 405ms
    }
}
