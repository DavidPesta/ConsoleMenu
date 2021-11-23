namespace ConsoleMenu
{
	public class EmptyOption : MenuAction
	{
		public EmptyOption(string menuText)
		{
			MenuText = menuText;
		}
		
		public override MenuSignal Action()
		{
			return MenuSignal.Continue;
		}
	}
}