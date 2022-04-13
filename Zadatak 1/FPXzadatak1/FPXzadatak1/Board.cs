using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPXzadatak1
{
    public class Board
    {
        public Coin[,] BoardLayout { get; set; }

        public Board()
        {
            BoardLayout = new Coin[6, 7];
            FillBoard();
        }

        public void ClearBoard()
        {
            Array.Clear(BoardLayout, 0, BoardLayout.Length);
        }

        public void FillBoard()
        {
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 7; j++)
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
