namespace ConsoleMenu
{
	public class AddToFlexibleMenuOption : MenuAction
	{
		public AddToFlexibleMenuOption()
		{
			Command = "a";
			MenuText = "Add Menu Item.";
		}
		
		public override MenuSignal Action()
		{
			Console.WriteLine("Enter a string to create the menu item.");
			string menuItem = Console.ReadLine();
			Data.AddFlexibleMenuOption(menuItem);
			
			return MenuSignal.Continue;
		}
	}
}