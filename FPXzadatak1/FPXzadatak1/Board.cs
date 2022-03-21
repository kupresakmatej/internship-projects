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
        }

        public bool IsRowFull()
        {
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    if(BoardLayout[i, j] != null)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
