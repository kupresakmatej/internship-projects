using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace FPX___Zadatak2
{
    public class Game
    {
        GameWindow gameWindow;
        List<Drawable> triangles;

        public Game(GameWindow window)
        {
            this.gameWindow = window;
            triangles = new List<Drawable>();
            Input();
            Start();
        }

        private List<Drawable> Input()
        {
            Console.WriteLine("Enter how many triangles you want to draw: ");
            int inputAmount = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < inputAmount; i++)
            {
                Console.WriteLine(string.Format("Enter the value for size of the {0}. triangle: ", i + 1));
                int inputSize = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the value for x: ");
                int x = Convert.ToInt32(Console.ReadLine()); 

                Console.WriteLine("Enter the value for y: ");
                int y = Convert.ToInt32(Console.ReadLine());

                triangles.Add(new Triangle(inputSize, x, y));
            }

            return triangles;
        }

        public void Start()
        {
            Renderer renderer = new Renderer(triangles, gameWindow);

            gameWindow.Load += Loaded;
            gameWindow.Resize += Resize;
            gameWindow.RenderFrame += renderer.RenderF;
            gameWindow.Run(1.0 / 60.0);
        }

        public void Resize(object o, EventArgs e)
        {
            GL.Viewport(0, 0, gameWindow.Width, gameWindow.Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-50.0, 50.0, -50.0, 50.0, -1.0, 1.0);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }

        public void Loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}
