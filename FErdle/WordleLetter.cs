using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FErdleHelper
{
    public class WordleLetter
    {
        public readonly char Value;
        public Colors Color;

        public WordleLetter(char letter)
        {
            Value = letter;
            Color = Colors.NONE;
        }

        public void NextColor()
        {
            if(Color < Colors.GREEN)
            {
                Color = (Colors)((int)Color + 1);
                return;
            }
            Color = Colors.GRAY;
        }

        public void PreviousColor()
        {
            if (Color > Colors.GRAY)
            {
                Color = (Colors)((int)Color - 1);
                return;
            }
            Color = Colors.GREEN;
        }
    }
}

