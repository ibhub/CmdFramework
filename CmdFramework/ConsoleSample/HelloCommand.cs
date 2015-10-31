using CmdFramework;
using System;
using System.Linq;

namespace ConsoleSample
{
	public class HelloCommand : BaseCommand
	{
		public HelloCommand() : base() { }

		public HelloCommand(string[] args) : base(args)
		{
			if (args == null || args.Length != 1)
				return;

			UserName = args.Single();
        }

		private string UserName { get; set; }

        public override string Name
		{
			get
			{
				return "hello";
			}
		}

		public override string Description
		{
			get
			{
				return string.Format("{0} name - display hello message in console", Name);
			}
		}

		public override void Process()
		{
			if (string.IsNullOrWhiteSpace(UserName))
			{
				Console.Write(Environment.NewLine);
				Console.WriteLine("Invalid input parameters");
				Console.Write(Environment.NewLine);
				Console.WriteLine(Description);
				return;
			}

			Console.WriteLine("Hello, {0}!", UserName);
		}
	}
}
