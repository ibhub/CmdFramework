using System;
using System.Linq;

namespace CmdFramework
{
	/// <summary>
	/// Command factory
	/// </summary>
	public static class CommandFactory
	{
		/// <summary>
		/// Get command by command-line arguments
		/// </summary>
		/// <param name="args">command-line arguments</param>
		public static BaseCommand Get(string[] args)
		{
			if (args == null || args.Length == 0)
				return new HelpCommand();

			string commandName = args.First();
			string[] commandArguments = args.Skip(1).ToArray();

			CommandProvider commandProvider = new CommandProvider();
			BaseCommand[] commands = commandProvider.CreateCommands(commandArguments)
				.Where(x => string.Equals(x.Name, commandName, StringComparison.OrdinalIgnoreCase))
				.ToArray();

			if (!commands.Any())
				return new UnknownCommand(commandName);

			if (commands.Count() > 1)
				throw new ArgumentException("It's impossible to implement multiple commands with same name");

			return commands.Single();

		}
	}
}
