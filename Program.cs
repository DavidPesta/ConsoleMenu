using ConsoleMenu;

var data = new ProgramData();

var mainMenu = new MainMenu();
mainMenu.SetData(data);
mainMenu.MenuInit();
mainMenu.Action();