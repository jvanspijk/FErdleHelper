using System;
using System.Collections.Generic;


namespace FErdle.View
{
    public static class InputReader
    {
        public static string TryReadString()
        {
            string input;
            try
            {
                input = Convert.ToString(Console.ReadLine());
                return input.ToLower();
            }
            catch
            {
                Console.WriteLine("");
                Console.WriteLine("Enter a word please.");
                TryReadString();
            }
            Console.WriteLine("Error in TryReadString");
            return "0";
        }

        public static char TryReadChar()
        {
            char input;
            try
            {
                input = Convert.ToChar(Console.ReadLine());
                input = Char.ToLower(input);
                if (input >= 'a' && input <= 'z')
                {
                    return input;
                }
                Console.WriteLine("Enter a letter please");
            }
            catch
            {
                Console.WriteLine("");
                Console.WriteLine("Enter a letter please.");
                TryReadChar();
            }
            Console.WriteLine("Error in TryReadChar");
            return '0';
        }

        public static int TryReadInt()
        {
            int input;
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
                return input;
            }
            catch
            {
                Console.WriteLine("");
                Console.WriteLine("Enter a number please.");
                TryReadInt();
            }
            Console.WriteLine("Error in TryReadInt");
            return '0';
        }

        public static ConsoleKey TryReadGuessMenu()
        {
            List<ConsoleKey> possibleKeys = new List<ConsoleKey>() { ConsoleKey.Escape, ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.Enter };

            var ch = Console.ReadKey(false).Key;
            try
            {
                if(possibleKeys.Contains(ch))
                {
                    return ch;
                }
                else
                {
                    TryReadGuessMenu();
                }
            }
            catch
            {
                TryReadGuessMenu();
            }
            return ch;
        }

        public static void WaitForUserInput()
        {            
            Console.ReadLine();
            Console.Clear();
        }

    }
}
