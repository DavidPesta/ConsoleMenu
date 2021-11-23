namespace InteractiveMenu
{
	public class ProgramData
	{
		private Dictionary<string, string> Data;
		
		public ProgramData()
		{
			Data = new Dictionary<string, string>()
			{
				{"stuff", "good"},
				{"things", "better"}
			};
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
	}
}