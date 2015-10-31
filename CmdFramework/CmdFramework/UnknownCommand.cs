using System;

namespace CmdFramework
{
	/// <summary>
	/// Command for unrecognized commands 
	/// </summary>
	public class UnknownCommand : BaseCommand
	{
		/// <summary>
		/// Unknown command name
		/// </summary>
		private string CommandName { get; set; }

		/// <summary>
		/// Default constructor
		/// </summary>
		public UnknownCommand() {}

		/// <summary>
		/// Constructor with unrecognized command
		/// </summary>
		public UnknownCommand(string commandName) { CommandName = commandName; }

		/// <summary>
		/// Initialization arguments constructor 
		/// </summary>
		public UnknownCommand(string[] args) : base(args) {}

		/// <summary>
		/// Unknown command name
		/// </summary>
		public override string Name
		{
			get { return CommandName; }
		}
		
		/// <summary>
		/// Unknown command description
		/// </summary>
		public override string Description
		{
			get { return "Unknown command"; }
		}

		/// <summary>
		/// Process command method
		/// </summary>
		public override void Process()
		{
			Console.Write(Environment.NewLine);
			Console.WriteLine(Description);
			new HelpCommand().Process();
		}
	}
}
