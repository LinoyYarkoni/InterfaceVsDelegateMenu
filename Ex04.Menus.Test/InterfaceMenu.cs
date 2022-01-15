namespace Ex04.Menus.Test
{
    public class InterfaceMenu
    {
        public static void RunInterfaceMenu()
        {
            Interfaces.Menu mainMenu = new Interfaces.Menu("Interface Main Menu");
            Interfaces.IMainMenu versionAndCapitals = mainMenu.AddMainMenu("Version and Capitals");

            versionAndCapitals.AddMenuItem("Count Capitals", new CountCapitalsActionItem());
            versionAndCapitals.AddMenuItem("Show Version", new ShowVersionActionItem());
            Interfaces.IMainMenu dateAndTime = mainMenu.AddMainMenu("Show Date/Time");

            dateAndTime.AddMenuItem("Show Date", new ShowDateActionItem());
            dateAndTime.AddMenuItem("Show Time", new ShowTimeActionItem());
            mainMenu.Show();
        }
    }
}