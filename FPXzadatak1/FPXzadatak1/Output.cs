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
            int rowLength = Logic.Instance.BoardLayout.GetLength(0);
            int columnLength = Logic.Instance.BoardLayout.GetLength(1);

            //string writeLine = " --- --- --- --- --- --- ---";

            int cursorPositionTop = Console.CursorTop;
            int cursorPositionLeft = Console.CursorLeft;

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(" --- --- --- --- --- --- ---");
                Console.WriteLine("|   |   |   |   |   |   |   |");
            }
            Console.WriteLine(" --- --- --- --- --- --- ---");

            cursorPositionTop = Console.CursorTop - 1;
            cursorPositionLeft = Console.CursorLeft;

            //for (int i = 0; i < rowLength; i++)
            //{
            //    Console.CursorTop = (cursorPositionTop - 1) + i;
            //    Console.CursorLeft = cursorPositionLeft + 1;

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

            for(int i = 0; i < rowLength - 1; i++)
            {
                Console.CursorTop = cursorPositionTop - 1;
                Console.CursorLeft = cursorPositionLeft + 1;

                if (Logic.Instance.BoardLayout[i, cursorPositionTop + i] != Coin.Empty)
                {
                    if (Logic.Instance.BoardLayout[i, cursorPositionTop + i] == Coin.PlayerA)
                    {
                        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Gameplay.firstPlayer.Color);
                    }
                    else if (Logic.Instance.BoardLayout[i, cursorPositionTop + i] == Coin.PlayerB)
                    {
                        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Gameplay.secondPlayer.Color);
                    }
                    Console.Write(string.Format(" 0 ").Insert(cursorPositionLeft, ""));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(string.Format(""));
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
