using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class Menu
    {
        private readonly List<IMainMenu> r_MainMenuList;
        private readonly string r_Title;

        public Menu(string i_Title)
        {
            this.r_MainMenuList = new List<IMainMenu>();
            this.r_Title = i_Title;
        }
        
        public IMainMenu AddMainMenu(string i_Title)
        {
            MainMenu newMainMenu = new MainMenu(i_Title);

            this.r_MainMenuList.Add(newMainMenu);

            return newMainMenu;
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
                    this.r_MainMenuList[userInput - 1].Show();
                }
            }
            while(userInput != 0);
        }

        private void showMenu()
        {
            int numberOfItems = this.r_MainMenuList.Count;
            StringBuilder currentMenu = new StringBuilder();

            currentMenu.AppendFormat("**{0}**{1}", this.r_Title, Environment.NewLine);
            currentMenu.AppendLine("-----------------------");
            for(int i = 0; i < numberOfItems; i++)
            {
                currentMenu.AppendFormat("{0} -> {1}{2}", i + 1, this.r_MainMenuList[i].Title, Environment.NewLine);
            }

            currentMenu.AppendLine("0 -> Exit");
            currentMenu.AppendLine("-----------------------");
            currentMenu.AppendFormat("Enter you request: (1 to {0} or press 0 to Exit)", numberOfItems);

            Console.WriteLine(currentMenu);
        }

        private int getUserIntInput()
        {
            int numberOfItems = r_MainMenuList.Count;
            bool isValidInput;
            int userInputInt;
            string userInput;

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
