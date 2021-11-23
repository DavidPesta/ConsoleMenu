namespace InteractiveMenu
{
	public class FlexibleOption : MenuAction
	{
		public FlexibleOption(string command, string menuText)
		{
			Command = command;
			MenuText = menuText;
		}
		
		public override MenuSignal Action()
		{
			Console.WriteLine($"Executing the {Command} option: {MenuText}.");
			Console.ReadLine();
			return MenuSignal.Continue;
		}
	}
}