using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowVersionActionItem : IActionItem
    {
        public void ActionItem()
        {
            Console.Clear();
            Console.WriteLine("Version: 22.1.4.8930{0}", Environment.NewLine);
        }
    }
}