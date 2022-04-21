using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FErdleHelper;

namespace FErdle.View
{
    public class MainView
    {        
        public MainView()
        {
            Console.Clear();
            Console.SetWindowSize(ProgramSettings.WINDOW_WIDTH, ProgramSettings.WINDOW_HEIGHT);
        }
        public void ShowMainMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Make a decision (1-4): ");
            Console.WriteLine("1: Fill in a guess");            
            Console.WriteLine("2: Show possible answers");
            Console.WriteLine("3: Restart");
            Console.WriteLine("4: Quit");
            Console.Write("Choice is: ");            
        }        
        
        public void ShowWrongMenuChoiceError()
        {
            Console.WriteLine("Enter a number from 1-4: ");            
        }

        public void ShowPossibleAnswers(IEnumerable<string> possibleAnswers)
        {
            const int CUT_OFF = 16;
            Console.WriteLine(possibleAnswers.Count() + " possible answers:");
            int wordCount = 0;

            foreach (string word in possibleAnswers)
            {
                if (wordCount > 0 && wordCount % CUT_OFF == 0)
                {
                    Console.WriteLine("");
                }
                Console.Write(word);
                Console.Write(", ");
                wordCount++;
            }

            Console.WriteLine("");
            WaitForUserInput();
        }        

        public void WaitForUserInput()
        {
            Console.WriteLine("Press Enter to continue...");
            InputReader.WaitForUserInput();
        }

        public void ClearView()
        {
            Console.Clear();
        }

        public void ShowQuitMessage()
        {
            ClearView();
            Console.WriteLine("Thanks for using the application!");
            WaitForUserInput();
        }

        internal void ShowRestartMessage()
        {
            ClearView();
            Console.WriteLine("Wordlist reset");
            WaitForUserInput();
        }
    }
}
