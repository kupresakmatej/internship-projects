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
                Console.WriteLine("Enter the value for a: ");
                int inputSize = Convert.ToInt32(Console.ReadLine());

                triangles.Add(new Triangle(inputSize, gameWindow));
            }

            return triangles;
        }

        public void Start()
        {
            Renderer renderer = new Renderer(triangles);

            gameWindow.Load += Loaded;
            gameWindow.Resize += Resize;
            gameWindow.RenderFrame += renderer.RenderF;
            gameWindow.Run(1.0 / 60.0); //time in seconds after which the window updates
        }

        public void Resize(object o, EventArgs e)
        {
            GL.Viewport(0, 0, gameWindow.Width, gameWindow.Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-50.0, 50.0, -50.0, 50.0, -1.0, 1.0);

            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void Loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}
