using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong.BallInformation;

namespace PingPong.PlayerInformation
{
    class Player : PrintAtPosition
    {
        private short _padSize;
        private short _position;
        private short _score;
        private char _symbol;
        private string _status;

        public short padSize
        {
            get { return _padSize; }
            set { _padSize = value; }
        }
        public short position
        {
            get { return _position; }
            set { _position = value; }
        }
        public short score
        {
            get { return _score; }
            set { _score = value; }
        }
        public char symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        public Player(short PadSize, short Position, short Score, char Symbol, string player_or_AI)
        {
            this.padSize = PadSize;
            this.position = Position;
            this.score = Score;
            this.symbol = Symbol;
            this.status = player_or_AI;
        }
        public static Player Move(Player player,Ball ball)
        {
            Random percent = new Random();
            switch (player.status)
            {
                case "player":
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key == ConsoleKey.W && player.position > 0)
                        {
                            player.position--;
                        }
                        else if (key.Key == ConsoleKey.S && player.position < Console.WindowHeight - player.padSize - 1)
                        {
                            player.position++;
                        }
                    }
                    break;
                case "AI":
                    int SuccessesRate = percent.Next(0, 101);
                    if (SuccessesRate <= 70)
                    {
                        if (player.position > 0 && ball.directionUp == true)
                            player.position--;
                        else if (player.position < Console.WindowHeight - player.padSize - 1)
                            player.position++;
                    }
                    break;
            }
            return player;
        }
        public static void DrawPosition1(Player player)
       {
           for (int y = player.position; y <= player.position + player.padSize; y++)
           {
               Print(0, y, player.symbol);
           }
       }
        public static void DrawPosition2(Player player)
        {
            for (int y = player.position; y <= player.position + player.padSize; y++)
            {
                Print(Console.WindowWidth - 1, y, player.symbol);
            }
        }
        public static void SetInitialPositon(Player player)
        {
            player.position = short.Parse(((Console.WindowHeight / 2) - (player.padSize / 2)).ToString());
        }
        public static void PrintScore(Player player1,Player player2)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
            Console.Write("{0} - {1}", player1.score, player2.score);
        }
    }
}
