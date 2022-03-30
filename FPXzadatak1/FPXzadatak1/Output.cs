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

        public void OutputBoard(int helper)
        {
            int rowLength = Logic.Instance.BoardLayout.GetLength(0);
            int columnLength = Logic.Instance.BoardLayout.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    if (Logic.Instance.BoardLayout[i, j] != Coin.Empty)
                    {
                        if(helper % 2 == 0)
                        {
                            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Gameplay.firstPlayer.Color);
                        }
                        else
                        {
                            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Gameplay.secondPlayer.Color);
                        }

                        Console.Write(string.Format("O "));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(string.Format("  "));
                    }
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
