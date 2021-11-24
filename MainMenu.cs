namespace ConsoleMenu
{
	public class MainMenu : Menu
	{
		public override void Compose()
		{
			Title = "Main Menu";
			Description = "This is a description of the contents of the main menu that might talk about what the overall purpose of the program is.";
			
			Add<FirstOption>();
			Add<FirstOption>();
			Add<EmptyOption>("==nothing==");
			Add<EmptyOption>("");
			Add<EmptyOption>("==here==");
			Add<DeeperMenu>("de");
			Add<FlexibleMenu>("f");
			Add<FlexibleOption>("1", "yay");
			Add<FlexibleOption>("2", "hoo");
			Add<FlexibleOption>("1", "eek");
			Add<EmptyOption>("");
			Add<ExitOption>();
		}
	}
}