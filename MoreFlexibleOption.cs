namespace ConsoleMenu
{
	public class MoreFlexibleOption : MenuAction
	{
		private string Identifier;
		
		public MoreFlexibleOption(string identifier)
		{
			// Note: No data available here, but not really needed yet. The constructor is simply used to initialize some basic defining characteristics.
			Identifier = identifier;
		}
		
		// Note: Can use Data and/or Identifier to determine Command and/or MenuText.
		public override string Command
		{
			get {
				return Data.Get("stuff");
			}
		}
		
		// Note: Can use Data and/or Identifier to determine Command and/or MenuText.
		public override string MenuText
		{
			get {
				return $"{Identifier} with data {Data.Get("things")}";
			}
		}
		
		public override MenuSignal Action()
		{
			Console.WriteLine($"Executing the {Command} option: {MenuText}.");
			Console.ReadLine();
			return MenuSignal.Continue;
		}
	}
}