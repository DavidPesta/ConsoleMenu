using System;
using System.Collections.Generic;

namespace InteractiveMenu
{
	public abstract class Menu : MenuAction
	{
		protected string Title;
		protected string Description;
		private List<MenuAction> MenuActions = new List<MenuAction>();
		private Dictionary<string, int> CommandIndex = new Dictionary<string, int>();
		
		public abstract void MenuInit();
		
		// https://stackoverflow.com/q/11234452/508558
		// https://stackoverflow.com/a/5598999/508558
		// https://stackoverflow.com/a/14983741/508558
		protected void Add<T>(params string[] args) where T : MenuAction
		{
			MenuAction action = (T)Activator.CreateInstance(typeof(T), args);
			SetupMenuAction(action);
		}
		/* Old way doesn't allow args:
		protected void Add<T>() where T : MenuAction, new()
		{
			MenuAction action = new T();
			SetupMenuAction(action);
		}
		*/
		
		private void SetupMenuAction(MenuAction action)
		{
			action.SetData(Data);
			
			if (action is Menu)
			{
				((Menu)action).MenuInit();
			}
			
			if (action.Command != null && CommandIndex.ContainsKey(action.Command))
			{
				Console.WriteLine($"Command \"{action.Command}\" is already used in this menu. Skipping \"{action.MenuDisplay()}\"");
				Console.ReadLine(); // https://stackoverflow.com/a/45479761/508558
				return;
			}
			
			if (action.Command != null)
			{
				CommandIndex[action.Command] = MenuActions.Count;
			}
			
			MenuActions.Add(action);
		}
		
		private void DisplayMenu()
		{
			Console.Clear();
			
			if (Title != null)
			{
				Console.WriteLine($"{Title}\n");
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
					if (CommandIndex.ContainsKey(command) == false)
					{
						Console.WriteLine($"Option \"{command}\" does not exist in this menu.");
					}
				} while(CommandIndex.ContainsKey(command) == false);
				
				menuSignal = MenuActions[CommandIndex[command]].Action();
			} while(menuSignal == MenuSignal.Continue);
			
			return MenuSignal.Continue;
		}
	}
}
