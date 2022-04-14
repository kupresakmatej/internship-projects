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
        private static string FLOATCHOICE = "x";
        private static string BYTECHOICE = "y";

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

                Console.WriteLine(string.Format("Do you want to enter float or byte values for color({0} for float, {1} for byte): ", FLOATCHOICE, BYTECHOICE));
                string colorType = Console.ReadLine();

                Console.Clear();

                if(colorType == FLOATCHOICE)
                {
                    Console.WriteLine("Choose color(enter 3 values 0-1 divided by a space): ");
                    string colorFloat = Console.ReadLine();

                    string[] colors = colorFloat.Split(' ');

                    float[] rgb = new float[3];

                    for(int j = 0; j < colors.Length - 1; j++)
                    {
                        rgb[j] += Convert.ToSingle(colors[j]);
                    }

                    triangles.Add(new Triangle(new Vector(x, y), inputSize, new Color(rgb[0], rgb[1], rgb[2])));
                }
                else if(colorType == BYTECHOICE)
                {
                    Console.WriteLine("Choose color(enter 3 values 0-255 divided by a space): ");
                    string colorFloat = Console.ReadLine();

                    string[] colors = colorFloat.Split(' ');

                    byte[] rgb = new byte[3];

                    for (int j = 0; j < colors.Length - 1; j++)
                    {
                        rgb[j] += Convert.ToByte(colors[j]);
                    }

                    triangles.Add(new Triangle(new Vector(x, y), inputSize, new Color(rgb[0], rgb[1], rgb[2])));
                }
            }

            return triangles;
        }

        public void Start()
        {
            Renderer renderer = new Renderer(triangles, gameWindow);

            GL.Viewport(0, 0, gameWindow.Width, gameWindow.Height);

            gameWindow.Load += Loaded;
            gameWindow.Resize += Resize;
            gameWindow.RenderFrame += renderer.RenderF;
            gameWindow.Run(1.0 / 60.0);
        }

        public void Resize(object o, EventArgs e)
        { 
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0.0, gameWindow.Width, 0.0, gameWindow.Height, -1.0, 1.0);

            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void Loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}
