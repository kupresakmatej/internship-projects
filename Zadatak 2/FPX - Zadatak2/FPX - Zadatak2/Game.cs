using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;
using System.Drawing;

namespace FPX___Zadatak2
{
    public class Game
    {
        private static string AFFIRMATIVE = "x";
        private static string NEGATIVE = "y";

        GameWindow gameWindow;
        List<Drawable> drawables;

        public Game(GameWindow window)
        {
            this.gameWindow = window;
            drawables = new List<Drawable>();
            Input();
            Start();
        }

        private List<Drawable> Input()
        {
            //Console.WriteLine(string.Format("Do you want to draw circles or triangles({0} for circles, {1} for triangles): ", AFFIRMATIVE, NEGATIVE));
            //string choice = Console.ReadLine();

            //CircleHole circleHole = new CircleHole(new Vector(0f, 0f), 50, 30, new Color(255, 0, 255), 250);
            //drawables.Add(circleHole);

            //Circle circle = new Circle(new Vector(0f, 0f), 100, new Color(255, 0, 123), 250);
            //drawables.Add(circle);

            Texture texture = new Texture();

            Quad quad = new Quad(new Vector(0f, 0f), 250, texture.GenerateTexture());
            drawables.Add(quad);

            //if (choice == AFFIRMATIVE) //circles
            //{
            //    Console.WriteLine("Enter how many circles you want to draw: ");
            //    int inputAmount = Convert.ToInt32(Console.ReadLine());

            //    Console.WriteLine("Enter how many triangles you want to circle to consist of: ");
            //    int triangleAmount = Convert.ToInt32(Console.ReadLine());

            //    for (int i = 0; i < inputAmount; i++)
            //    {
            //        Console.Clear();

            //        Console.WriteLine(string.Format("Enter the value for radius of the {0}. circle: ", i + 1));
            //        int inputRadius = Convert.ToInt32(Console.ReadLine());

            //        Console.WriteLine("Enter the value for x: ");
            //        int x = Convert.ToInt32(Console.ReadLine());

            //        Console.WriteLine("Enter the value for y: ");
            //        int y = Convert.ToInt32(Console.ReadLine());

            //        Console.WriteLine(string.Format("Do you want to enter float or byte values for color({0} for float, {1} for byte): ", AFFIRMATIVE, NEGATIVE));
            //        string colorType = Console.ReadLine();

            //        Console.Clear();

            //        if (colorType == AFFIRMATIVE)
            //        {
            //            Console.WriteLine("Choose color(enter 3 values 0-1 divided by a space): ");
            //            string colorFloat = Console.ReadLine();

            //            string[] colors = colorFloat.Split(' ');

            //            float[] rgb = new float[3];

            //            for (int j = 0; j < colors.Length; j++)
            //            {
            //                rgb[j] += float.Parse(colors[j]);
            //            }

            //            drawables.Add(new Circle(new Vector(x, y), inputRadius, new Color(rgb[0], rgb[1], rgb[2]), triangleAmount));
            //        }
            //        else if (colorType == NEGATIVE)
            //        {
            //            Console.WriteLine("Choose color(enter 3 values 0-255 divided by a space): ");
            //            string colorFloat = Console.ReadLine();

            //            string[] colors = colorFloat.Split(' ');

            //            byte[] rgb = new byte[3];

            //            for (int j = 0; j < colors.Length; j++)
            //            {
            //                rgb[j] += byte.Parse(colors[j]);
            //            }

            //            drawables.Add(new Circle(new Vector(x, y), inputRadius, new Color(rgb[0], rgb[1], rgb[2]), triangleAmount));
            //        }
            //    }
            //}
            //else if (choice == NEGATIVE) //triangles
            //{
            //    Console.WriteLine("Enter how many triangles you want to draw: ");
            //    int inputAmount = Convert.ToInt32(Console.ReadLine());

            //    for (int i = 0; i < inputAmount; i++)
            //    {
            //        Console.Clear();

            //        Console.WriteLine(string.Format("Enter the value for size of the {0}. triangle: ", i + 1));
            //        int inputSize = Convert.ToInt32(Console.ReadLine());

            //        Console.WriteLine("Enter the value for x: ");
            //        int x = Convert.ToInt32(Console.ReadLine());

            //        Console.WriteLine("Enter the value for y: ");
            //        int y = Convert.ToInt32(Console.ReadLine());

            //        Console.WriteLine(string.Format("Do you want to enter float or byte values for color({0} for float, {1} for byte): ", AFFIRMATIVE, NEGATIVE));
            //        string colorType = Console.ReadLine();

            //        Console.Clear();

            //        if (colorType == AFFIRMATIVE)
            //        {
            //            Console.WriteLine("Choose color(enter 3 values 0-1 divided by a space): ");
            //            string colorFloat = Console.ReadLine();

            //            string[] colors = colorFloat.Split(' ');

            //            float[] rgb = new float[3];

            //            for (int j = 0; j < colors.Length; j++)
            //            {
            //                rgb[j] += float.Parse(colors[j]);
            //            }

            //            drawables.Add(new Triangle(new Vector(x, y), inputSize, new Color(rgb[0], rgb[1], rgb[2])));
            //        }
            //        else if (colorType == NEGATIVE)
            //        {
            //            Console.WriteLine("Choose color(enter 3 values 0-255 divided by a space): ");
            //            string colorFloat = Console.ReadLine();

            //            string[] colors = colorFloat.Split(' ');

            //            byte[] rgb = new byte[3];

            //            for (int j = 0; j < colors.Length; j++)
            //            {
            //                rgb[j] += byte.Parse(colors[j]);
            //            }

            //            drawables.Add(new Triangle(new Vector(x, y), inputSize, new Color(rgb[0], rgb[1], rgb[2])));
            //        }
            //    }
            //}

            drawables.Sort((x, y) => x.Layer.CompareTo(y.Layer));
            return drawables;
        }

        public void Start()
        {
            Renderer renderer = new Renderer(drawables, gameWindow);

            //GL.Viewport(0, 0, gameWindow.Width, gameWindow.Height);

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
            GL.Ortho(0.0, gameWindow.Width, 0.0, gameWindow.Height, -1.0, 1.0);

            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void Loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}
