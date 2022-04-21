using System;

namespace FErdleHelper.View
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
            Console.WriteLine("Make a decision (1-5): ");
            Console.WriteLine("1: Fill in a guess");            
            Console.WriteLine("2: Show possible answers");
            Console.WriteLine("3: Show most occuring characters");
            Console.WriteLine("4: Restart");
            Console.WriteLine("5: Quit");
            Console.Write("Choice is: ");            
        }        
        
        public void ShowWrongMenuChoiceError()
        {
            Console.WriteLine("Enter a number from 1-5: ");            
        }
        
        public void ClearView()
        {
            Console.Clear();
        }

        public void ShowQuitMessage()
        {
            ClearView();
            Console.WriteLine("Thanks for using the application!");
            InputReader.WaitForUserInput();
        }

        public void ShowRestartMessage()
        {
            ClearView();
            Console.WriteLine("Wordlist reset");
            InputReader.WaitForUserInput();
        }
    }
}
