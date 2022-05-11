using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace FPX___Zadatak2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(1280, 720);
            Game game = new Game(window);
        }
    }
}
