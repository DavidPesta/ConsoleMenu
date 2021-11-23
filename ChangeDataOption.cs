namespace ConsoleMenu
{
	public class ChangeDataOption : MenuAction
	{
		public ChangeDataOption()
		{
			Command = "c";
			MenuText = "Change data.";
		}
		
		public override MenuSignal Action()
		{
			Console.WriteLine("What key to change?");
			string key = Console.ReadLine();
			Console.WriteLine("What value to set it to?");
			string value = Console.ReadLine();
			Data.Set(key, value);
			return MenuSignal.Continue;
		}
	}
}