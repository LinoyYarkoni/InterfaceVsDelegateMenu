namespace Ex04.Menus.Test
{
    public class DelegateMenu
    {
        public static void RunDelegateMenu()
        {
            Delegates.MainMenu mainMenu = new Delegates.MainMenu("Delegates Main Menu");
            Delegates.MenuItem versionAndCapitals = mainMenu.AddMenu("Version and Capitals");

            versionAndCapitals.AddMenuItem("Count Capitals", new CountCapitalsActionItem().ActionItem);
            versionAndCapitals.AddMenuItem("Show Version", new ShowVersionActionItem().ActionItem);
            Delegates.MenuItem dateAndTime = mainMenu.AddMenu("Show Date/Time");

            dateAndTime.AddMenuItem("Show Date", new ShowDateActionItem().ActionItem);
            dateAndTime.AddMenuItem("Show Time", new ShowTimeActionItem().ActionItem);
            mainMenu.Show();
        }
    }
}