namespace InteractiveMenu
{
	public class FirstOption : MenuAction
	{
		public FirstOption()
		{
			Command = "one";
			MenuText = "The first option.";
		}
		
		public override MenuSignal Action()
		{
			Console.WriteLine("Executing the first option. What key to get?");
			string key = Console.ReadLine();
			
			if (Data.Contains(key))
			{
				Console.WriteLine($"Got the {Data.Get(key)}.");
			}
			else
			{
				Console.WriteLine($"The key {key} could not be found in the data.");
			}
			
			Console.ReadLine();
			
			return MenuSignal.Continue;
		}
	}
}
