﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPXzadatak1
{

    //public enum Coins
    //{
    //    PlayerA,
    //    PlayerB,
    //    Empty
    //}

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
