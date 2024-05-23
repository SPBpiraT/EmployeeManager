using EmployeeManager.Data;

namespace EmployeeManager.Handlers
{
    internal class CreateDbCommandHandler
    {
        public CreateDbCommandHandler() 
        {
            Handle();
        }
        private void Handle()
        {
            using (EmployeesDbContext db = new EmployeesDbContext())
            {
                db.Database.EnsureCreated();
                Console.WriteLine("Db was created.");
            }
        }
    }
}
