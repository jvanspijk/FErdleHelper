using System;

namespace FErdle
{
    public class Menu
    {
        private WordList words;
        public bool end;
        private Decisions decision;
        
        public Menu()
        {
            words = new WordList();
            end = false;
            Console.SetWindowSize(120, 28);
        }
        
        public void ShowMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Make a decision (1-6): ");
            Console.WriteLine("1: Fill in gray letter");
            Console.WriteLine("2: Fill in yellow letter");
            Console.WriteLine("3: Fill in green letter");
            Console.WriteLine("4: Show possible answers");
            Console.WriteLine("5: Restart");
            Console.WriteLine("6: End");
            Console.Write("Choice is: ");            
            int input = TryReadInt();            
            MakeDecision(input);            
        }

        public void MakeDecision(int decision)
        {
            Console.Clear();
            char letter;
            int position;
            switch (decision)
            {
                case 1:
                    Console.Write("It does not contain the letter: ");
                    letter = TryReadChar();
                    words.AnswerDoesNotHaveLetter(letter);
                    break;
                case 2:
                    Console.Write("It contains the letter: ");
                    letter = TryReadChar();
                    Console.Write("Position is not: ");
                    position = TryReadInt();
                    words.AnswerHasLetterNotOnPosition(letter, position);
                    break;
                case 3:
                    Console.Write("It contains the letter: ");
                    letter = TryReadChar();
                    Console.Write("Position is: ");
                    position = TryReadInt();
                    words.AnswerHasLetterOnPosition(letter, position);
                    break;                
                case 4:
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

        public char TryReadChar()
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

        public int TryReadInt()
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
