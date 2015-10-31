# CmdFramework
Light command line framework written in C#

Framework allows you to create console applications running on the command line by writing classes for a specific console commands. 

## Sample
Usage sample is available in the CmdFramework.ConsoleSample project.

### Using
App require that you have the following using statement:
```cs
using CmdFramework;
```

### Commands processing
Process command code in Main function:
```cs
		static void Main(string[] args)
		{
			BaseCommand command = CommandFactory.Get(args);
			command.Process();
    }
```

### Create custom command
Cutom command must be inherited from BaseCommand. 
```cs
	public class HelloCommand : BaseCommand
	{
		public HelloCommand() : base() { }
		public HelloCommand(string[] args) : base(args)	{ }

		public override string Name
		{
			get
			{
				return "hello"; // command name
			}
		}

		public override string Description
		{
			get
			{
				return "hello - displays hello message"; // command description
			}
		}

		public override void Process()
		{
				// Process command code 
		}
	}
```

### Usage
```
> ConsoleSample.exe hello
```
