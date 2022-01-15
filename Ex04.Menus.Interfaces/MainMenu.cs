using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    internal class MainMenu : IMainMenu
    {
        private readonly List<IMenu> r_ItemList;
        private readonly string r_Title;

        public MainMenu(string i_Title)
        {
            this.r_Title = i_Title;
            this.r_ItemList = new List<IMenu>();
        }

        public string Title
        {
            get
            {
                return this.r_Title;
            }
        }

        public void AddMenuItem(string i_ItemName, IActionItem i_ActionItem)
        {
            MenuItem menuItem = new MenuItem(i_ItemName, i_ActionItem);

            this.r_ItemList.Add(menuItem);
        }

        public void Show()
        {
            int userInput;

            do
            {
                showMenu();
                userInput = getUserIntInput();
                if(userInput != 0)
                {
                    this.r_ItemList[userInput - 1].Show();
                }
            }
            while(userInput != 0);
        }

        private void showMenu()
        {
            int numberOfItems = this.r_ItemList.Count;
            StringBuilder currentMenu = new StringBuilder();

            currentMenu.AppendFormat("**{0}**{1}", this.r_Title, Environment.NewLine);
            currentMenu.AppendLine("-----------------------");
            for(int i = 0; i < numberOfItems; i++)
            {
                currentMenu.AppendFormat("{0} -> {1}{2}", i + 1, this.r_ItemList[i].Title, Environment.NewLine);
            }

            currentMenu.AppendLine("0 -> Back");
            currentMenu.AppendLine("-----------------------");
            currentMenu.AppendFormat("Enter you request: (1 to {0} or press 0 to Back)", numberOfItems);
            Console.WriteLine(currentMenu);
        }

        private int getUserIntInput()
        {
            bool isValidInput;
            int userInputInt;
            string userInput;

            do
            {
                isValidInput = true;
                userInput = Console.ReadLine();

                if(int.TryParse(userInput, out userInputInt))
                {
                    if(userInputInt < 0 || userInputInt > this.r_ItemList.Count)
                    {
                        Console.WriteLine("Input must be in range 0 to {0}", this.r_ItemList.Count);
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