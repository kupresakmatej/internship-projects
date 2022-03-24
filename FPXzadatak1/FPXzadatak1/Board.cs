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
        
        public void ClearBoard()
        {
            Array.Clear(BoardLayout, 0, BoardLayout.Length);
        }
    }
}
