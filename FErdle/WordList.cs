using System;
using System.Collections.Generic;
using System.Linq;

namespace FErdleHelper
{
    public class WordList
    {
        
        private List<string> _answers = new List<string>();        

        private IEnumerable<string> _possibleAnswers;

        public WordList()
        {
            InitPossibleAnswers();
        }

        public void InitPossibleAnswers()
        {
            _possibleAnswers = _answers;
        }

        public void AddWordlist(List<string> words)
        {
            foreach(string word in words)
            {
                if(!_answers.Contains(word))
                {
                    _answers.Add(word);
                }                
            }
        }

        public void AnswerHasLetterNotOnPosition(char letter, int pos)
        {            
            _possibleAnswers = _possibleAnswers.Where(word => word.Contains(letter) && word[pos] != letter);           
        }

        public void AnswerHasLetterOnPosition(char letter, int pos)
        {
            _possibleAnswers = _possibleAnswers.Where(word => word[pos] == letter);
        }

        public void AnswerDoesNotHaveLetter(char letter)
        {
            _possibleAnswers = _possibleAnswers.Where(word => !word.Contains(letter));
        }

        public void ReinitializeWordList()
        {
            _possibleAnswers = _answers;
        }

        public IEnumerable<string> GetPossibleAnswers()
        {
            return _possibleAnswers;
        }

       public List<char> GetMostOccurringCharacters(int amountCharsToReturn)
        {
            Dictionary<char, int> mostOccurringCharacters = new Dictionary<char, int>();            
            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                mostOccurringCharacters.Add(ch, CountOccurrancesOfChar(ch));
            }
            amountCharsToReturn = NormalizeAmountOfCharsToReturn(amountCharsToReturn, mostOccurringCharacters.Count());   
            

            return mostOccurringCharacters.OrderByDescending(ch => ch.Value)
                                      .Select(ch => ch.Key)
                                      .Take(amountCharsToReturn).ToList();
        }

        private int NormalizeAmountOfCharsToReturn(int amountCharsToReturn, int listSize)
        {
            int amountChars = Math.Min(amountCharsToReturn, 26);
            amountChars = Math.Min(amountChars, listSize);
            amountChars = Math.Max(1, amountChars);
            return amountChars;
        }

        public int CountOccurrancesOfChar(char ch)
        {
            return _possibleAnswers.Where(word => word.Contains(ch)).Count();            
        }       
    }
}
