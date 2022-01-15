namespace Ex04.Menus.Interfaces
{
    public interface IMainMenu : IMenu
    {
        void AddMenuItem(string i_Title, IActionItem i_ActionItem);
    }
}