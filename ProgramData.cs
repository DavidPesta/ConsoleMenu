namespace ConsoleMenu
{
	public class ProgramData
	{
		private Dictionary<string, string> Data;
		private List<string> FlexibleMenuOptions;
		
		public ProgramData()
		{
			Data = new Dictionary<string, string>()
			{
				{"stuff", "good"},
				{"things", "better"}
			};
			
			FlexibleMenuOptions = new List<string>();
		}
		
		public string GetStuff()
		{
			return Data["stuff"];
		}
		
		public string GetThings()
		{
			return Data["things"];
		}
		
		public string Get(string key)
		{
			return Data[key];
		}
		
		public void Set(string key, string value)
		{
			Data[key] = value;
		}
		
		public bool Contains(string key)
		{
			return Data.ContainsKey(key);
		}
		
		public void AddFlexibleMenuOption(string option)
		{
			FlexibleMenuOptions.Add(option);
		}
		
		public List<string> GetFlexibleMenuOptions()
		{
			return FlexibleMenuOptions;
		}
	}
}