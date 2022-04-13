using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPXzadatak1
{
    public class Output
    {
        public const string AFFIRMATIVE_INPUT = "y";
        public const string NEGATIVE_INPUT = "x";

        private static Board board;

        public Output(Board Board)
        {
            board = Board;
        }

        public void OutputWinMessage(int helper)
        {
            string winner;

            if((helper - 2) % 2 == 0)
            {
                winner = Gameplay.firstPlayer.Name;
            }
            else
            {
                winner = Gameplay.secondPlayer.Name;
            }

            Console.WriteLine(string.Format("{0} congratulations, you won!", winner));
            Console.WriteLine(Environment.NewLine);
        }

        public void OutputWinMessageSP(int helper)
        {
            string winner;

            if ((helper - 2) % 2 == 0)
            {
                winner = Gameplay.firstPlayer.Name;
            }
            else
            {
                winner = Gameplay.secondPlayer.Name;
            }

            Console.WriteLine(string.Format("{0} congratulations, you won!", winner));
            Console.WriteLine(Environment.NewLine);
        }

        public void OutputBoard()
        {
            Console.WriteLine(" --- --- --- --- --- --- ---");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write("|");
                    if (board.BoardLayout[i, j] != Coin.Empty)
                    {
                        if (board.BoardLayout[i, j] == Coin.PlayerA)
                        {
                            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Gameplay.firstPlayer.Color);
                        }
                        else if (board.BoardLayout[i, j] == Coin.PlayerB)
                        {
                            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Gameplay.secondPlayer.Color);
                        }
                        Console.Write(string.Format(" 0 "));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(string.Format(" X "));
                    }
                }
                Console.Write("|");
                Console.WriteLine(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine(" --- --- --- --- --- --- ---");
        }
    }
}
