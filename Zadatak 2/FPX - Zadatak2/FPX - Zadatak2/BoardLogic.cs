using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPX___Zadatak2
{
    public class BoardLogic
    {
        public Coin[,] BoardLayout { get; set; }

        public BoardLogic()
        {
            BoardLayout = new Coin[6, 7];
        }

        public void FillBoard()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    BoardLayout[i, j] = Coin.Empty;
                }
            }
        }

        public void PrintBoard()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.WriteLine(BoardLayout[i, j]);
                }
            }
        }

    }
}
