using CommandLine;
using EmployeeManager;
using EmployeeManager.Handlers;

public class Program
{
    static void Main(string[] args)
    {
        CommandLine.Parser.Default.ParseArguments<CLOptions>(args)
          .WithParsed(RunAppMode)
          .WithNotParsed(HandleParseError);
    }
    static void RunAppMode(CLOptions opts)
    {
        switch (opts.Mode)
        {
            case 1:
                new CreateDbCommandHandler();
                break;
            case 2:
                if (opts.Props.Count() == 3) new AddEmployeeCommandHandler(opts.Props.ToArray());
                else Console.WriteLine("Wrong format.");
                break;
            case 3:
                new GetUniqueEmployeesHandler();
                break;
            case 4:
                new FillDatabaseCommandHandler();
                break;
            case 5:
                new GetSpecialEmployeesCommandHandler();
                break;

            default:
                Console.WriteLine("Wrong parameters.");
                break;
        }
    }
    static void HandleParseError(IEnumerable<Error> errs)
    {
        Console.WriteLine("Error");
    }
}
