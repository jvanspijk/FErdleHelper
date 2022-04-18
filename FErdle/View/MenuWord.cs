using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FErdle.View
{
    class MenuWord
    {

        MenuWord()
        {
            
        }
        public void ShowMainMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Make a decision (1-4): ");
            Console.WriteLine("1: Fill in a guess");            
            Console.WriteLine("2: Show possible answers");
            Console.WriteLine("3: Restart");
            Console.WriteLine("4: End");
            Console.Write("Choice is: ");            
        }

        public void MainMenuChoice()
        {
            MenuChoices choice  = (MenuChoices)InputReader.TryReadInt();

            switch(choice)
            {
                case MenuChoices.GUESS:
                    Console.Write("It does not contain the letter: ");
                    letter = TryReadChar();
                    words.AnswerDoesNotHaveLetter(letter);
                    break;
                case MenuChoices.SHOW_ANSWERS:
                    Console.Write("It contains the letter: ");
                    letter = TryReadChar();
                    Console.Write("Position is not: ");
                    position = TryReadInt();
                    words.AnswerHasLetterNotOnPosition(letter, position);
                    break;
                case MenuChoices.RESTART:
                    Console.Write("It contains the letter: ");
                    letter = TryReadChar();
                    Console.Write("Position is: ");
                    position = TryReadInt();
                    words.AnswerHasLetterOnPosition(letter, position);
                    break;
                case MenuChoices.RESTART:
                    words.ShowPossibleAnswers();
                    break;
                case 5:
                    words.ReinitializeWordList();
                    break;
                case 6:
                    end = true;
                    break;
                default:
                    Console.WriteLine("Enter a number from 1-6: ");
                    break;

            }
        }

        public 


    }
}
