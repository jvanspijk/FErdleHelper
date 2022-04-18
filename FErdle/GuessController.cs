using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FErdle.View;

namespace FErdle
{
    public class GuessController
    {
        private const int WORD_LENGTH = 5;

        private GuessView _view;
        private int _selectedPosition;
        private WordleLetter[] _guess;

        private bool _guessConfirmed;
        private bool _escapePressed;
        
        private WordList _wordList;

        public GuessController(WordList wordList)
        {
            _wordList = wordList;
        }

        public void FillInGuess()
        {
            _view = new GuessView();
            _view.AskGuessedWord();
            string guess = InputReader.TryReadString();
            _guess = ConvertStringToWordleArray(guess);                      
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
            char[] guessArray = guess.ToCharArray();
            WordleLetter[] wordleGuess = new WordleLetter[5];
            for (int i = 0; i < 5; i++)
            {
                wordleGuess[i] = new WordleLetter(guessArray[i]);
            }
            return wordleGuess;
        }
        public void SelectNext()
        {
            if (_selectedPosition >= WORD_LENGTH - 1)
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
                _selectedPosition = WORD_LENGTH - 1;
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
