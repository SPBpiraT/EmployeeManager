using CommandLine;

namespace EmployeeManager
{
    internal class CLOptions
    {

        [Value(0, MetaName = "mode", HelpText = "App mode.")]
        public byte Mode { get; set; }

        [Value(0, MetaName = "props", HelpText = "Properties.")]
        public IEnumerable<string> Props
        {
            get;
            set;
        }
    }
}
