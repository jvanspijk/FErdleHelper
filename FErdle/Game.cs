using System;
using System.Collections.Generic;
using FErdleHelper.View;

namespace FErdleHelper
{
    public class Game
    {
        private MainView _view;
        private StatsView _statsView;
        private WordList _words;
        private GuessController _guessController;

        public bool GameRunning;

        public Game()
        {
            GameRunning = true;
            _view = new MainView();
            _statsView = new StatsView();
            _words = new WordList();
        }

        public void Run()
        {
            while (GameRunning)
            {
                _view.ShowMainMenu();
                MenuChoices choice = (MenuChoices)InputReader.TryReadInt();
                _view.ClearView();
                HandleMenuChoice(choice);
            }
        }
        public void HandleMenuChoice(MenuChoices choice)
        {
            switch (choice)
            {
                case MenuChoices.GUESS:
                    OpenGuessMenu();
                    break;
                case MenuChoices.SHOW_ANSWERS:
                    ShowAnswers();
                    break;
                case MenuChoices.MOST_OCCURING_CHARS:
                    OpenCharCountScreen();
                    break;
                case MenuChoices.RESTART:
                    RestartGame();
                    break;
                case MenuChoices.END:
                    EndGame();
                    break;
                default:
                    HandleWrongMenuChoice();
                    break;
            }
            _view.ClearView();
        }

        private void OpenCharCountScreen()
        {
            _statsView.AskForAmountOfChars();
            int amountCh = InputReader.TryReadInt();
            _view.ClearView();
            ShowMostOccurringChars(amountCh);            
        }

        private void ShowMostOccurringChars(int amountCh)
        {
            List<char> chars = _words.GetMostOccurringCharacters(amountCh);
            foreach(char ch in chars)
            {
                _statsView.ShowCharAndOccurance(ch, _words.CountOccurrancesOfChar(ch));
            }
            _statsView.ShowExitMessage();
        }

        private void OpenGuessMenu()
        {
            _guessController = new GuessController(_words);
            _guessController.FillInGuess();
            _guessController.ChangeGuessColors();
        }

        private void ShowAnswers()
        {
            _statsView.ShowPossibleAnswers(_words.GetPossibleAnswers());
        }

        private void RestartGame()
        {
            _words.ReinitializeWordList();
            _view.ShowRestartMessage();
        }


        public void EndGame()
        {
            GameRunning = false;
            _view.ShowQuitMessage();
        }

        private void HandleWrongMenuChoice()
        {
            _view.ShowWrongMenuChoiceError();
        }

    }
}
