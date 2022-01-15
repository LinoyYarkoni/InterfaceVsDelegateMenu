using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private readonly string r_Title;
        protected List<MenuItem> m_MenuItems;
        protected string m_BackOrExit = "Exit";
        
        public MainMenu(string i_Title)
        {
            this.m_MenuItems = new List<MenuItem>();
            this.r_Title = i_Title;
        }

        public string Title
        {
            get
            {
                return this.r_Title;
            }
        }

        public MenuItem AddMenu(string i_Title)
        {
            MenuItem menuItem = new MenuItem(i_Title, null);

            this.m_MenuItems.Add(menuItem);

            return menuItem;
        }

        public void AddMenuItem(string i_Title, Action i_Action)
        {
            MenuItem menuItem = new MenuItem(i_Title, i_Action);

            this.m_MenuItems.Add(menuItem);
        }

        public void Show()
        {
            int userInput;

            do
            {
                this.ShowMenu();
                userInput = this.getUserIntInput();
                if(userInput != 0)
                {
                    this.m_MenuItems[userInput - 1].RunOnAction();
                }
            }
            while(userInput != 0);
        }

        protected void ShowMenu()
        {
            int numberOfItems = this.m_MenuItems.Count;
            StringBuilder currentMenu = new StringBuilder();

            currentMenu.AppendFormat("**{0}**{1}", this.r_Title, Environment.NewLine);
            currentMenu.AppendLine("-----------------------");
            for(int i = 0; i < numberOfItems; i++)
            {
                currentMenu.AppendFormat("{0} -> {1}{2}", i + 1, this.m_MenuItems[i].Title, Environment.NewLine);
            }

            currentMenu.AppendFormat("0 -> {0}{1}", this.m_BackOrExit, Environment.NewLine);
            currentMenu.AppendLine("-----------------------");
            currentMenu.AppendFormat("Enter you request: (1 to {0} or press 0 to {1})", numberOfItems, this.m_BackOrExit);
            Console.WriteLine(currentMenu);
        }

        private int getUserIntInput()
        {
            bool isValidInput;
            int userInputInt;
            string userInput;
            int numberOfItems = this.m_MenuItems.Count;

            do
            {
                userInput = Console.ReadLine();
                isValidInput = true;

                if(int.TryParse(userInput, out userInputInt))
                {
                    if(userInputInt < 0 || userInputInt > numberOfItems)
                    {
                        Console.WriteLine("Input must be in range 0 to {0}", numberOfItems);
                        isValidInput = false;
                    }
                }
                else if(userInput == string.Empty)
                {
                    Console.WriteLine("Input can not be empty");
                    isValidInput = false;
                }
                else
                {
                    Console.WriteLine("Input must a be number");
                    isValidInput = false;
                }
            }
            while(!isValidInput);

            return userInputInt;
        }
    }
}
