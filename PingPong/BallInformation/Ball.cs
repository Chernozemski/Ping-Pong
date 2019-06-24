using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong.PlayerInformation;

namespace PingPong.BallInformation
{
    class Ball : PrintAtPosition
    {
        private short _posX;
        private short _posY;
        private bool _directionUp;
        private bool _directionLeft;
        private char _symbol;

        public short posX
        {
            get { return _posX; }
            set { _posX = value; }
        }
        public short posY
        {
            get { return _posY; }
            set { _posY = value; }
        }
        public bool directionUp
        {
            get { return _directionUp; }
            set { _directionUp = value; }
        }
        public bool directionLeft
        {
            get { return _directionLeft; }
            set { _directionLeft = value; }
        }
        public char symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        public Ball(short Position_X, short Position_Y, bool Direction_Up, bool Direction_Left, char Symbol)
        {
            this.posX = Position_X;
            this.posY = Position_Y;
            this.directionUp = Direction_Up;
            this.directionLeft = Direction_Left;
            this.symbol = Symbol;
        }
        public static void Move(Ball ball,Player player1,Player player2)
        {
            if (ball.posY == 0)
            {
                ball.directionUp = false;
            }
            if (ball.posY == Console.WindowHeight - 1)
            {
                ball.directionUp = true;
            }

            if (ball.posX == 0)
            {
                ball.directionLeft = false;
                player2.score++;
                ball.posY = short.Parse((Console.WindowHeight / 2).ToString());
                ball.posX = short.Parse((Console.WindowWidth / 2).ToString());
            }
            if (ball.posX == Console.WindowWidth - 1)
            {
                ball.directionLeft = true;
                player1.score++;
                ball.posY = short.Parse((Console.WindowHeight / 2).ToString());
                ball.posX = short.Parse((Console.WindowWidth / 2).ToString());
            }

            if (ball.posX < 2
                && ball.posY >= player1.position
                && ball.posY <= player1.position + player1.padSize)
            {
                ball.directionLeft = false;
            }
            if (ball.posX > Console.WindowWidth - 3 - 1
                && ball.posY >= player2.position
                && ball.posY <= player2.position + player2.padSize)
            {
                ball.directionLeft = true;
            }


            if (ball.directionUp)
            {
                ball.posY--;
            }
            else
            {
                ball.posY++;
            }

            if (ball.directionLeft)
            {
                ball.posX--;
            }
            else
            {
                ball.posX++;
            }
        }
        public static void Draw(Ball ball)
        {
            Print(ball.posX, ball.posY, ball.symbol);
        }
        public static void SetInitialPoisition(Ball ball)
        {
            ball.posX = short.Parse((Console.WindowWidth / 2).ToString());
            ball.posY = short.Parse((Console.WindowHeight / 2).ToString());
        }
    }
}
