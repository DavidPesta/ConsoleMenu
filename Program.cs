namespace InteractiveMenu
{
	class Program
	{
		static void Main(string[] args)
		{
			var data = new ProgramData();
			
			var mainMenu = new MainMenu();
			mainMenu.SetData(data);
			mainMenu.MenuInit();
			mainMenu.Action();
		}
	}
}
