namespace ConsoleMenu
{
	public class FlexibleMenu : Menu
	{
		public FlexibleMenu(string command)
		{
			Command = command;
			MenuText = "Flexible Menu";
		}
		
		public override void Compose()
		{
			var options = Data.GetFlexibleMenuOptions();
			
			Title = "Flexible Menu";
			Description = $"This menu contains {options.Count} items!";
			
			var command = 1;
			foreach (var option in options)
			{
				Add<FlexibleOption>(command.ToString(), option);
				command++;
			}
			
			Add<EmptyOption>("");
			Add<AddToFlexibleMenuOption>();
			Add<ExitOption>();
		}
	}
}