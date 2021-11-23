namespace ConsoleMenu
{
	public class ExitOption : MenuAction
	{
		public ExitOption()
		{
			Command = "x";
			MenuText = "Exit the menu.";
		}
		
		public override MenuSignal Action()
		{
			return MenuSignal.Exit;
		}
	}
}