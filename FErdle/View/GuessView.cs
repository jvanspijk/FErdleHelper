using System;

namespace FErdleHelper.View
{
    public class GuessView
    {      
        
        public void AskGuessedWord()
        {
            Console.Clear();
            Console.WriteLine("What word did you fill in?");
        }
        public void ShowWordWithColors(int selectedPosition, WordleLetter[] word)
        {
            Console.Clear();
            UseDefaultColor();
            Console.WriteLine("Set the correct color of every letter using the arrow keys: ");
            Console.WriteLine("");            
            Console.WriteLine("↑ ↑ ↑ ↑ ↑");
            foreach(WordleLetter letter in word)
            {
                SetLetterColor(letter.Color);                
                //Console.Write(letter.Value + " ");
                Console.Write($"{ letter.Value } ");
                UseDefaultColor();
            }
            
            Console.WriteLine("");
            Console.WriteLine("↓ ↓ ↓ ↓ ↓");
            Console.WriteLine("");
            Console.WriteLine("Press ESCAPE to go back, press ENTER to confirm your selection.");
            SetCursorPosition(selectedPosition);            
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void ShowWordSizeError()
        {            
            Console.WriteLine($"Please enter a word that is { ProgramSettings.WORD_LENGTH } characters long");            
            InputReader.WaitForUserInput();
        }

        private void UseDefaultColor()
        {
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void SetCursorPosition(int selectedLetter)
        {
            int selectedPosition;
            if(selectedLetter == 0)
            {
                selectedPosition = 0;
            }
            else
            {
                selectedPosition = selectedLetter * 2;
            }
            Console.SetCursorPosition(selectedPosition, 3);
        }

        public void SetLetterColor(Colors color)
        {
            switch (color)
            {
                case Colors.NONE:
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case Colors.GRAY:
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case Colors.YELLOW:
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    break;
                case Colors.GREEN:
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
            }                
        }      

    }
}
