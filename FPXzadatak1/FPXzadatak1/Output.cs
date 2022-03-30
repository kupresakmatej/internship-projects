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

        private static Board board = new Board();

        public Output()
        {
            board.FillBoard();
        }

        public void OutputWinMessage(int helper)
        {
            string winner;

            if((helper - 1) % 2 == 0)
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
            int rowLength = board.BoardLayout.GetLength(0);
            int columnLength = board.BoardLayout.GetLength(1);


            Console.WriteLine(" --- --- --- --- --- --- ---");
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
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

            //int cursorPositionTop = Console.CursorTop;
            //int cursorPositionLeft = Console.CursorLeft;

            //for (int i = 0; i < rowLength; i++)
            //{
            //    //Console.CursorTop = (cursorPositionTop - 2) + (i - 5);
            //    //Console.CursorLeft = cursorPositionLeft + 1;

            //    Console.SetCursorPosition(cursorPositionLeft + 1, cursorPositionTop - 2);

            //    for (int j = 0; j < columnLength; j++)
            //    {
            //        if (Logic.Instance.BoardLayout[i, j] != Coin.Empty)
            //        {
            //            if (Logic.Instance.BoardLayout[i, j] == Coin.PlayerA)
            //            {
            //                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Gameplay.firstPlayer.Color);
            //            }
            //            else if (Logic.Instance.BoardLayout[i, j] == Coin.PlayerB)
            //            {
            //                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Gameplay.secondPlayer.Color);
            //            }
            //            Console.Write(string.Format(" 0 ").Insert(cursorPositionLeft, ""));
            //            Console.ForegroundColor = ConsoleColor.White;
            //            Console.Write("|");
            //        }
            //        else
            //        {
            //            Console.ForegroundColor = ConsoleColor.White;
            //            Console.Write(string.Format(""));
            //        }
            //    }
            //    Console.ForegroundColor = ConsoleColor.White;
            //}
        }
    }
}
