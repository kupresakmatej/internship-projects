using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPXzadatak1
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Gameplay game = new Gameplay();

            //game.Start();

            Board board = new Board();
            //Logic logic = new Logic(board);

            board.FillBoard();
            PrintSmth();

            //board.PrintBoard();

            //logic.FallIntoPlace(1, 0);

            //Console.WriteLine(Environment.NewLine);

            //board.PrintBoard();
        }

        static void PrintSmth()
        {
            int ROWS_COUNT = 6;
            int COLUMNS_COUNT = 7;

            for (int i = 0; i < ROWS_COUNT; i++)
            {
                //Coin[] coins = new Coin[i];

                for (int j = 0; j < i; j++)
                {
                    Console.WriteLine(string.Format("{0} {1}", j, COLUMNS_COUNT - i + j));
                }
                Console.WriteLine();
            }


            //for (int i = 0; i < ROWS_COUNT; i++)
            //{
            //    for (int j = 0; j < i; j++)
            //    {
            //        Console.WriteLine(string.Format("{0} {1}", ROWS_COUNT - i + j, j));
            //    }
            //    Console.WriteLine();
            //}

            //for (int i = 0; i < ROWS_COUNT; i++)
            //{
            //    for (int j = 0; j < i; j++)
            //    {
            //        Console.WriteLine(string.Format("{0} {1}", ROWS_COUNT - i + 1 + j, COLUMNS_COUNT - j - 1));
            //    }
            //    Console.WriteLine();
            //}

            //for (int i = 0; i < ROWS_COUNT; i++)
            //{
            //    for(int j = 0; j < i; j++)
            //    {
            //        Console.WriteLine(string.Format("{0} {1}", ROWS_COUNT - j, i - j - 1));
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
