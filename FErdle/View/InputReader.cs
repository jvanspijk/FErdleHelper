using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return Char.ToLower(input);
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

    }
}
