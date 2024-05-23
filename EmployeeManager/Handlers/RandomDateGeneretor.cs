namespace EmployeeManager.Handlers
{
    internal static class RandomDateGeneretor
    {
        static Random random = new Random();
        public static DateTime GenRandomDateTime()
        {
            DateTime from = new DateTime(1900, 1, 1);
            DateTime to = DateTime.UtcNow;

            if (random == null)
            {
                random = new Random();
            }
            TimeSpan range = to - from;
            var randts = new TimeSpan((long)(random.NextDouble() * range.Ticks));
            return from + randts;
        }
    }
}
