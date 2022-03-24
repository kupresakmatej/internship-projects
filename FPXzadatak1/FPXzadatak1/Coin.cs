using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Coin
{
    PlayerA,
    PlayerB,
    Empty
}

namespace FPXzadatak1
{
    public class Coin
    {
        public string Color { get; set; }

        public Coin()
        {

        }

        public Coin(string color)
        {
            Color = color;
        }
    }
}
