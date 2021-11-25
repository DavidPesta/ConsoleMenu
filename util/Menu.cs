namespace ConsoleMenu
{
	public abstract class Menu : MenuAction
	{
		public virtual string Title { get; protected set; }
		public virtual string Description { get; protected set; }
		private List<MenuAction> MenuActions = new List<MenuAction>();
		
		// GOTCHA: Do not have a command index, even though it would help performance (negligible for a menu)
		// because if a command changes, this CommandIndex does not get updated.
		//private Dictionary<string, int> CommandIndex = new Dictionary<string, int>();
		
		public abstract void Compose();
		
		// https://stackoverflow.com/q/11234452/508558
		// https://stackoverflow.com/a/5598999/508558
		// https://stackoverflow.com/a/14983741/508558
		protected void Add<T>(params string[] args) where T : MenuAction
		{
			MenuAction action = (T)Activator.CreateInstance(typeof(T), args);
			SetupMenuAction(action);
		}
		
		private void SetupMenuAction(MenuAction action)
		{
			action.SetData(Data);
			
			if (CommandFoundInMenuActions(action.Command))
			{
				Console.WriteLine($"Command \"{action.Command}\" is already used in this menu. Skipping \"{action.MenuDisplay()}\"");
				Console.ReadLine(); // https://stackoverflow.com/a/45479761/508558
				return;
			}
			
			MenuActions.Add(action);
		}
		
		private void DisplayMenu()
		{
			MenuActions.Clear();
			Compose();
			
			Console.Clear();
			
			if (Title != null)
			{
				Console.WriteLine($"{Color.Bold}{Color.Underline}{Title}{Color.Normal}\n");
			}
			
			if (Description != null)
			{
				Console.WriteLine($"{Description}\n");
			}
			
			foreach (var menuAction in MenuActions)
			{
				Console.WriteLine(menuAction.MenuDisplay());
			}
		}
		
		public override MenuSignal Action()
		{
			MenuSignal menuSignal;
			do {
				DisplayMenu();
				
				string command;
				do {
					Console.WriteLine("\nChoose Option:");
					command = Console.ReadLine();
					
					if (CommandFoundInMenuActions(command) == false)
					{
						Console.WriteLine($"Option \"{command}\" does not exist in this menu.");
					}
					
				} while(CommandFoundInMenuActions(command) == false);
				
				menuSignal = PerformCommandAction(command);
			} while(menuSignal == MenuSignal.Continue);
			
			return MenuSignal.Continue;
		}
		
		private bool CommandFoundInMenuActions(string command)
		{
			foreach (MenuAction menuAction in MenuActions)
			{
				if (menuAction.Command != null && menuAction.Command == command)
				{
					return true;
				}
			}
			
			return false;
		}
		
		private MenuSignal PerformCommandAction(string command)
		{
			foreach (MenuAction menuAction in MenuActions)
			{
				if (menuAction.Command != null && menuAction.Command == command)
				{
					return menuAction.Action();
				}
			}
			
			return MenuSignal.Continue;
		}
	}
}