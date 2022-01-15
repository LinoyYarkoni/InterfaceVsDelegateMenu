using System;

namespace Ex04.Menus.Delegates
{
    public class MenuItem : MainMenu
    {
        public event Action Action;

        public MenuItem(string i_Title, Action i_Action) : base(i_Title)
        {
            this.m_BackOrExit = "Back";
            this.Action += i_Action;
        }

        public void RunOnAction()
        {
            this.OnAction();
        }

        protected virtual void OnAction()
        {
            if(this.Action != null)
            {
                this.Action.Invoke();
            }
            else
            {
                Show();
            }
        }
    }
}
