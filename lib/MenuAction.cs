namespace InteractiveMenu
{
	public abstract class MenuAction
	{
		protected ProgramData Data;
		
		public virtual string Command {get; protected set;}
		public virtual string MenuText {get; protected set;}
		
		public abstract MenuSignal Action();
		
		public void SetData(ProgramData data)
		{
			Data = data;
		}
		
		public string MenuDisplay()
		{
			string display = "";
			
			if (Command == null)
			{
				display = MenuText;
			}
			else
			{
				display = $"\x1B[1m\x1B[92m{Command}\x1B[0m. {MenuText}";
			}
			
			return display;
		}
	}
}
