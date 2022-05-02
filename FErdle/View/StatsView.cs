using System;
using System.Collections.Generic;
using System.Linq;


namespace FErdleHelper.View
{
    public class StatsView
    {
        public void Clear()
        {
            Console.Clear();
        }
        public void AskForAmountOfChars()
        {
            Console.WriteLine("How many letters do you want to see the occurances of?");            
        }

        public void ShowPossibleAnswers(IEnumerable<string> possibleAnswers)
        {
            const int CUT_OFF = 16;
            Console.WriteLine($"{ possibleAnswers.Count() } possible answers:");
            int wordCount = 0;

            foreach (string word in possibleAnswers)
            {
                if (wordCount > 0 && wordCount % CUT_OFF == 0)
                {
                    Console.WriteLine("");
                }
                Console.Write($"{ word }, ");                
                wordCount++;
            }

            Console.WriteLine("");
            InputReader.WaitForUserInput();
        }

        public void ShowCharAndOccurance(char ch, int occurrances)
        {            
            Console.WriteLine($"{ ch }: { occurrances } occurances found.");
        }

        public void ShowExitMessage()
        {
            Console.WriteLine("");
            InputReader.WaitForUserInput();
        }
    }
}
