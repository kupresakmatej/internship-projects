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

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    if (Logic.Instance.BoardLayout[i, j] != null)
                    {
                        if (Logic.Instance.BoardLayout[i, j].Color == "blue")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if (Logic.Instance.BoardLayout[i, j].Color == "yellow")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else if (Logic.Instance.BoardLayout[i, j].Color == "green")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (Logic.Instance.BoardLayout[i, j].Color == "red")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }

                        Console.Write(string.Format("1 "));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(string.Format("0 "));
                    }
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
