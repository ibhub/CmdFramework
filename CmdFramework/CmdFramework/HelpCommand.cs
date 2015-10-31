using System;
using System.Linq;

namespace CmdFramework
{
	/// <summary>
	/// Help command
	/// </summary>
	public class HelpCommand : BaseCommand
	{
		/// <summary>
		/// Default constructor
		/// </summary>
		public HelpCommand() {}

		/// <summary>
		/// Initialization arguments constructor 
		/// </summary>
		public HelpCommand(string[] args) : base(args) {}

		/// <summary>
		/// Help command name
		/// </summary>
		public override string Name
		{
			get { return "help"; }
		}

		/// <summary>
		/// Help description
		/// </summary>
		public override string Description
		{
			get
			{
				return string.Format("{0} - Displays help information.", Name);
			}
		}

		/// <summary>
		/// Process help command
		/// </summary>
		public override void Process()
		{
			Console.Write(Environment.NewLine);

			CommandProvider commandProvider = new CommandProvider();

			BaseCommand[] commands = commandProvider.CreateCommands(null)
				.Where(x => x.Name != Name)
				.OrderBy(x => x.Name)
				.ToArray();

			Console.WriteLine(Description);

			foreach (var command in commands)
				Console.WriteLine(command.Description);

			Console.Write(Environment.NewLine);
		}
	}
}
