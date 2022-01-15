using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowDateActionItem : IActionItem
    {
        public void ActionItem()
        {
            Console.Clear();
            Console.WriteLine("The date is: {0}", DateTime.Today.ToShortDateString());
        }
    }
}