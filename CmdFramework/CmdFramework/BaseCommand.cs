namespace CmdFramework
{
	/// <summary>
	/// Base command
	/// </summary>
	public abstract class BaseCommand
	{
		/// <summary>
		/// Default constructor
		/// </summary>
		protected BaseCommand() { }

		/// <summary>
		/// Initialization arguments constructor 
		/// </summary>
		protected BaseCommand(string[] args) { Arguments = args; }

		/// <summary>
		/// Command arguments
		/// </summary>
		protected string[] Arguments { get; private set; }

		/// <summary>
		/// Command name
		/// </summary>
		public abstract string Name { get; }

		/// <summary>
		/// Command description
		/// </summary>
		public virtual string Description { get { return null; } }

		/// <summary>
		/// Process command method
		/// </summary>
		public abstract void Process();
	}
}
