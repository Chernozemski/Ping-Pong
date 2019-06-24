using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using PingPong.PlayerInformation;
using PingPong.BallInformation;

namespace PingPong
{
    class Game
    {
        static Player player1 = new Player(4,0,0,'A', "player");
        static Player player2 = new Player(4, 0, 0, 'A', "AI");
        static Ball ball = new Ball(0,0,true,true,'o');

        public static void Run()
        {
            //on startup
            SetWindowSize();
            SetColor();
            Showbanner();
            Player.SetInitialPositon(player1);
            Player.SetInitialPositon(player2);
            Ball.SetInitialPoisition(ball);

            bool end = false;

            while (end == false)
            {
                //game
                Player.Move(player1,ball);
                Player.Move(player2,ball);
                Ball.Move(ball,player1,player2);

                Console.Clear();

                Player.DrawPosition1(player1);
                Player.DrawPosition2(player2);
                Ball.Draw(ball);

                Player.PrintScore(player1, player2);
                SlowDown();
                end = Outcome.Determine(player1, player2);
            }
        }
       private static void SetWindowSize()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }
       private static void SetColor()
       {
           Console.ForegroundColor = ConsoleColor.Green;
       }  
       private static void SlowDown()
       {
           Thread.Sleep(60);
       }
       private static void Showbanner()
       {
           int left = Console.WindowWidth / 3;
           int top = Console.WindowHeight / 2;
           PrintAtPosition.Print(left, top, "Welcome to the game : PingPong.");
           PrintAtPosition.Print(left, top++, "The first who scores 3 points wins.");
           PrintAtPosition.Print(left, top++, "Contorls:");
           PrintAtPosition.Print(left, top++, "Move up : W");
           PrintAtPosition.Print(left, top++,"Move down : S");
           Console.ReadKey();
       }
    }
}
