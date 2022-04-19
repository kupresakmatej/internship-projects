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
            GameWindow window = new GameWindow(500, 500);
            Game game = new Game(window);

            //string colorFloat = "1 0 0";

            //string[] colors = colorFloat.Split(' ');
            //float[] rgbs = new float[3];

            //for(int i = 0; i < colors.Length; i++)
            //{
            //    rgbs[i] = float.Parse(colors[i]);
            //}


            //foreach(float rgb in rgbs)
            //{
            //    Console.WriteLine(rgb);
            //}

            //Circle circle = new Circle(new Vector(0f, 0f), 50, new Color(255, 0, 123), 250, 4);

            //Console.WriteLine(circle.Layer);
        }
    }
}
