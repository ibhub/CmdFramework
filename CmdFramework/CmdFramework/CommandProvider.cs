using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CmdFramework
{
	/// <summary>
	/// Command Provider class
	/// </summary>
	public class CommandProvider
	{
		/// <summary>
		/// Domain assemblies
		/// </summary>
		private IEnumerable<Assembly> Assemblies
		{
			get
			{
				return AppDomain.CurrentDomain.GetAssemblies();
			}
		}

		/// <summary>
		/// Command types
		/// </summary>
		private IEnumerable<Type> CommandTypes
		{
			get
			{
				var activatorType = typeof(BaseCommand);
				var unknownCommandType = typeof(UnknownCommand);

				return Assemblies
					.SelectMany(x => x.GetTypes())
					.Where(x => activatorType.IsAssignableFrom(x) && x != activatorType)
					.Where(x => x != unknownCommandType);
			}
		}

		/// <summary>
		/// Create commands
		/// </summary>
		/// <param name="args">arguments</param>
		public IEnumerable<BaseCommand> CreateCommands(string[] args)
		{
			return CommandTypes
				.Select(type => (BaseCommand) Activator.CreateInstance(type, new object[] {args}));
		}
	}
}
