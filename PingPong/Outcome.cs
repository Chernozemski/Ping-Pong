using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong
{
    class Outcome
    {
        public static bool Determine(PlayerInformation.Player a, PlayerInformation.Player b)
        {
            int left = Console.WindowWidth / 3;
            int top = Console.WindowHeight / 2;

            if (a.score == 3)
            {
                PrintAtPosition.Print(left, top, "First player wins");
                return true;
            }

            else if (b.score == 3)
            {
                PrintAtPosition.Print(left, top, "Second player wins");
                return true;
            }
            return false;
        }
    }
}
