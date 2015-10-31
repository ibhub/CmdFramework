using CmdFramework;

namespace ConsoleSample
{
	class Program
	{
		static void Main(string[] args)
		{
			BaseCommand command = CommandFactory.Get(args);
			command.Process();
        }
	}
}
