using System;

namespace FErdle
{
    class Program
    {
        static void Main(string[] args)
        {            
            Menu menu = new Menu();
            while(menu.end == false)
            {
                menu.ShowMenu();
            }
            Environment.Exit(0);
        }       
    }
}
