namespace EmployeeManager.Data.Entity
{
    internal class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

        public int GetAge()
        {
            DateTime now = DateTime.Today;
            int age = now.Year - BirthDate.Year;
            if (BirthDate > now.AddYears(-age)) age--;
            return age;
        }
    }
}
