using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPXzadatak1
{
    public class Player
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public bool IsPlaying { get; set; }

        public Player(string name, string color)
        {
            Name = name;
            Color = color;
            IsPlaying = false;
        }

        public Player()
        {

        }
    }
}
