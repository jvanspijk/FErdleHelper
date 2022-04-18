using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FErdle
{
    public enum Decisions
    {
        gray = 1,
        yellow = 2,
        green = 3,
        restart = 4,
        end = 5
    }

    public class DecisionsFunc
    {
        public Decisions IntToDecision(int i)
        {
            return (Decisions)i;
        }
        public Decisions StringToDecision(string decision)
        {
            return (Decisions) Enum.Parse(typeof(Decisions), decision);
        }
    }
}
   
