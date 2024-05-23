using EmployeeManager.Data;

namespace EmployeeManager.Handlers
{
    internal class GetUniqueEmployeesHandler
    {
        public GetUniqueEmployeesHandler() 
        {
            Handle();
        }
        private void Handle()
        {
            using (EmployeesDbContext db = new EmployeesDbContext())
            {
                var uniqueEmployeeRecords = db.Employees
                .GroupBy(e => new { e.FirstName, e.LastName, e.MiddleName, e.BirthDate })
                .Select(g => g.First())
                .ToList()
                .OrderBy(e => e.LastName)
                .ThenBy(e => e.FirstName)
                .ThenBy(e => e.MiddleName);

                foreach (var employee in uniqueEmployeeRecords)
                {
                    string fullName = $"{employee.LastName} {employee.FirstName} {employee.MiddleName}";

                    Console.WriteLine("FullName: {0}, BirthDate: {1}, Gender: {2}, Age: {3}", 
                                        fullName, employee.BirthDate, employee.Gender, employee.GetAge());
                }
            }
        }
    }
}
