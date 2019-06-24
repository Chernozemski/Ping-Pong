using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong
{
    abstract class PrintAtPosition
    {
        public static void Print(int X, int y, string text)
        {
            Console.SetCursorPosition(X, y);
            Console.Write(text);
        }
        public static void Print(int X, int y, char symbol)
        {
            Console.SetCursorPosition(X, y);
            Console.Write(symbol);
        }
    }
}
