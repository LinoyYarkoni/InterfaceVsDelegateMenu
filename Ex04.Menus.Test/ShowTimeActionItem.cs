using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowTimeActionItem : IActionItem
    {
        public void ActionItem()
        {
            Console.Clear();
            Console.WriteLine("The time is: {0}", DateTime.Now.ToShortTimeString());
        }
    }
}