using EmployeeManager.Data;
using EmployeeManager.Data.Entity;

namespace EmployeeManager.Handlers
{
    internal class FillDatabaseCommandHandler
    {
        private readonly List<Employee> randomEmployees = new List<Employee>();
        private Random rand = new Random();

        public FillDatabaseCommandHandler()
        {
            Handle();
        }

        private void Handle()
        {
            GenerateRandomEmployees(1000000, randomEmployees);
            GenerateSpecialEmployees(100, randomEmployees);
            InsertDataBatch(randomEmployees);
        }

        private void GenerateRandomEmployees(int count, List<Employee> employees)
        {
            Console.WriteLine("Generation...");
            for (int i = 0; i < count; i++)
            {
                employees.Add(new Employee
                {
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last(),
                    MiddleName = Faker.Name.Middle(),
                    BirthDate = RandomDateGeneretor.GenRandomDateTime().Date,
                    Gender = Faker.Enum.Random<Gender>()
                });
            }
            Console.WriteLine("Generation random completed.");

        }
        private void GenerateSpecialEmployees(int count, List<Employee> employees)
        {
            string[] namesStartsWithP = employees.Where(e => e.FirstName.StartsWith("P"))
                                                 .Select(n => n.FirstName)
                                                 .Take(100)
                                                 .ToArray();

            for (int i = 0; i < count; i++)
            {
                employees.Add(new Employee
                {
                    FirstName = Faker.Name.First(),
                    LastName = namesStartsWithP[rand.Next(namesStartsWithP.Count() - 1)],
                    MiddleName = Faker.Name.Middle(),
                    BirthDate = RandomDateGeneretor.GenRandomDateTime(),
                    Gender = Gender.Male
                });
            }
            Console.WriteLine("Generation special completed.");
        }

        private void InsertDataBatch(List<Employee> employees)
        {
            Console.WriteLine("Insertion...");
            using (EmployeesDbContext db = new EmployeesDbContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var emp in employees)
                        {
                            db.Employees.Add(emp);
                        }

                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error inserting data: " + ex.Message);
                    }
                }
            }
            Console.WriteLine("Insertion completed.");
        }
    }
}
