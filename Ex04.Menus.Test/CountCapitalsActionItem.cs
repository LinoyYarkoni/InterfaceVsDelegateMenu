using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CountCapitalsActionItem : IActionItem
    {
        private int m_NumberOfUpper = 0;

        public void ActionItem()
        {
            Console.Clear();
            Console.WriteLine("Please enter your sentence:");
            string userInput = Console.ReadLine();

            foreach(char currentChar in userInput)
            {
                if(char.IsUpper(currentChar))
                {
                    m_NumberOfUpper++;
                }
            }

            string letterOrLetters = m_NumberOfUpper == 0 ? "letter" : "letters";

            Console.WriteLine("The sentence contains {0} upper case {1}{2}", m_NumberOfUpper, letterOrLetters, Environment.NewLine);
        }
    }
}