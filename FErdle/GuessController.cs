using System;
using FErdle.View;
using FErdleHelper;

namespace FErdle
{
    public class GuessController
    {
        private GuessView _view;
        private int _selectedPosition;
        private WordleLetter[] _guess;

        private bool _guessConfirmed;
        private bool _escapePressed;
        
        private WordList _wordList;

        public GuessController(WordList wordList)
        {
            _wordList = wordList;
            _view = new GuessView();
        }

        public void FillInGuess()
        {
            string guess;
            while (true)
            {
                guess = AskForGuess();
                if(guess.Length == ProgramSettings.WORD_LENGTH)
                {
                    _guess = ConvertStringToWordleArray(guess);
                    break;
                }
                else
                {
                    _view.ShowWordSizeError();
                    _view.Clear();
                }               
            }                              
        }

        private string AskForGuess()
        {
            _view.AskGuessedWord();
            string guess = InputReader.TryReadString();
            return guess;
        }

        public void ChangeGuessColors()
        {
            while (_guessConfirmed == false && _escapePressed == false)
            {                
                _view.ShowWordWithColors(_selectedPosition, _guess);
                HandleGuessMenu();
            }            
        }

        private void HandleGuessMenu()
        {
            ConsoleKey key = InputReader.TryReadGuessMenu();
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    NextColor();
                    break;
                case ConsoleKey.DownArrow:
                    PreviousColor();
                    break;
                case ConsoleKey.LeftArrow:
                    SelectPrevious();
                    break;
                case ConsoleKey.RightArrow:
                    SelectNext();
                    break;
                case ConsoleKey.Enter:
                    if(GuessValid())
                    {
                        _guessConfirmed = true;
                        RemoveWordsFromWordList();
                        return;
                    }
                    break;
                case ConsoleKey.Escape:
                    _escapePressed = true;
                    break;
                default:
                    break;
            }            
        }
       

        private bool GuessValid()
        {
            foreach(WordleLetter letter in _guess)
            {
                if(letter.Color == Colors.NONE)
                {
                    return false;
                }
            }
            return true;
        }

        private WordleLetter[] ConvertStringToWordleArray(string guess)
        {
            int wordLength = ProgramSettings.WORD_LENGTH;
            char[] guessArray = guess.ToCharArray();
            WordleLetter[] wordleGuess = new WordleLetter[wordLength];
            for (int i = 0; i < wordLength; i++)
            {
                wordleGuess[i] = new WordleLetter(guessArray[i]);
            }
            return wordleGuess;
        }
        public void SelectNext()
        {
            if (_selectedPosition >= ProgramSettings.WORD_LENGTH - 1)
            {
                _selectedPosition = 0;
                return;
            }
            _selectedPosition++;
        }

        public void SelectPrevious()
        {
            if (_selectedPosition <= 0)
            {
                _selectedPosition = ProgramSettings.WORD_LENGTH - 1;
                return;
            }
            _selectedPosition--;
        }

        public void NextColor()
        {
            _guess[_selectedPosition].NextColor();
        }

        public void PreviousColor()
        {
            _guess[_selectedPosition].PreviousColor();
        }

        private void RemoveWordsFromWordList()
        {
            int index = 0;
            foreach(WordleLetter letter in _guess)
            {
                switch(letter.Color)
                {
                    case Colors.GRAY:
                        _wordList.AnswerDoesNotHaveLetter(letter.Value);
                        break;
                    case Colors.YELLOW:
                        _wordList.AnswerHasLetterNotOnPosition(letter.Value, index);
                        break;
                    case Colors.GREEN:
                        _wordList.AnswerHasLetterOnPosition(letter.Value, index);
                        break;
                    default:
                        throw new Exception();
                }
                index++;
            }
        }

    }
}
