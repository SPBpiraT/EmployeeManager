using EmployeeManager.Data;
using EmployeeManager.Data.Entity;

namespace EmployeeManager.Handlers
{
    internal class AddEmployeeCommandHandler
    {
        private string[] Props { get; set; }
        public AddEmployeeCommandHandler(string[] props) 
        {
            Props = props;
            Handle();
        }
        private void Handle()
        {
            using (EmployeesDbContext db = new EmployeesDbContext())
            {
                if (db.Database.CanConnect())
                {
                    if (DateTime.TryParse(Props[1], out DateTime birthDate)) { } //TODO: Add birthdate validator
                    else
                    {
                        Console.WriteLine("Wrong format.");
                        return;
                    }

                    string[] splittedName = Props[0].Split(' ');

                    Employee employee = new Employee()
                    {
                        FirstName = splittedName[1],
                        LastName = splittedName[0],
                        MiddleName = splittedName[2],
                        BirthDate = birthDate,
                        Gender =  (Gender)Enum.Parse(typeof(Gender), Props[2]) //TODO: Add gender validator
                };

                    db.Employees.Add(employee);
                    db.SaveChanges();

                    Console.WriteLine("Success.");
                }
                else Console.WriteLine("Unable to connect to the database.");
            }
        }
    }
}
