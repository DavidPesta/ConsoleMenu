namespace InteractiveMenu
{
	public class DeeperMenu : Menu
	{
		public DeeperMenu(string command)
		{
			Command = command;
			MenuText = "Deeper Menu";
		}
		
		public override void MenuInit()
		{
			// Note: Data can be used here to build the menu title, description, and options.
			
			Title = "Deeper Menu";
			Description = $"This goes deeper. This is really {Data.GetStuff()}";
			
			Add<FirstOption>();
			Add<ChangeDataOption>();
			Add<MoreFlexibleOption>("id1");
			Add<ExitOption>();
		}
	}
}
