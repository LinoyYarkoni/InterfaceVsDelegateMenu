namespace Ex04.Menus.Interfaces
{
    internal class MenuItem : IMenu
    {
        private readonly string r_Title;
        private readonly IActionItem r_Action;

        public MenuItem(string i_Title, IActionItem i_Action)
        {
            this.r_Title = i_Title;
            this.r_Action = i_Action;
        }

        public string Title
        {
            get
            {
                return this.r_Title;
            }
        }

        public void Show()
        {
            this.r_Action.ActionItem();
        }
    }
}
