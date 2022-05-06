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
        GameWindow gameWindow;
        List<IDrawable> drawables;
        Board board;

        private List<Circle> circles = new List<Circle>();

        private Circle circle;

        Color color = new Color();

        public Game(GameWindow window)
        {
            this.gameWindow = window;
            drawables = new List<IDrawable>();
            board = new Board(gameWindow);

            circle = new Circle(new Vector(gameWindow.Width/2, gameWindow.Height/2), 10f, color.Yellow, 250);
            drawables.Add(circle);

            Input();
            Start();
        }

        public Game()
        {

        }

        private List<IDrawable> Input()
        {
            List<IDrawable> drawBoard;
            drawBoard = board.GenerateBoard(gameWindow.Width, gameWindow.Height);

            foreach(IDrawable drawable in drawBoard)
            {
                drawables.Add(drawable);
            }

            drawables.Sort((x, y) => x.Layer.CompareTo(y.Layer));
            return drawables;
        }

        public void Start()
        {
            Renderer renderer = new Renderer(drawables, gameWindow);

            drawables.Add(circle);

            //GL.Viewport(0, 0, gameWindow.Width, gameWindow.Height);

            gameWindow.Load += Loaded;
            gameWindow.Resize += Resize;
            gameWindow.MouseMove += FollowMouse;
            gameWindow.MouseDown += DrawOnMouse;
            gameWindow.RenderFrame += renderer.RenderF;
            gameWindow.RenderFrame += DropCoin;
            gameWindow.Run(1.0 / 60.0);
        }

        public void DropCoin(object o, EventArgs e)
        {
            foreach(Circle circle in circles)
            {
                circle.Position = new Vector(circle.Position.X, circle.Position.Y - 5f);
            }

            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public void Resize(object o, EventArgs e)
        {
            OnResize?.Invoke();

            OnResize += () => board.WindowReshape(gameWindow.Width, gameWindow.Height, circles);

            GL.Viewport(0, 0, gameWindow.Width, gameWindow.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, gameWindow.Width, 0, gameWindow.Height, -1, 1);

            GL.MatrixMode(MatrixMode.Modelview);
        }

        public event Action OnResize;

        public void DrawOnMouse(object o, EventArgs e)
        {
            var mouse = OpenTK.Input.Mouse.GetCursorState();

            float x = mouse.X - gameWindow.Bounds.X;
            float y = gameWindow.Height - (mouse.Y - gameWindow.Bounds.Y);

            if (x > (gameWindow.Bounds.Width / 2 - 50f) && x < (gameWindow.Bounds.Width / 2 + 50f)) //4. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 10f, gameWindow.Height / 2 + 350f), 30f, color.Yellow, 250);

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if ((x < (gameWindow.Bounds.Width / 2 - 50f) && x > (gameWindow.Bounds.Width / 2 - 150f))) //3. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 - 90f, gameWindow.Height / 2 + 350f), 30f, color.Yellow, 250);

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if ((x < (gameWindow.Bounds.Width / 2 - 150f) && x > (gameWindow.Bounds.Width / 2 - 250f))) //2. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 - 190f, gameWindow.Height / 2 + 350f), 30f, color.Yellow, 250);

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if ((x < (gameWindow.Bounds.Width / 2 - 250f) && x > (gameWindow.Bounds.Width / 2 - 350f))) //1. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 - 290f, gameWindow.Height / 2 + 350f), 30f, color.Yellow, 250);

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if ((x > (gameWindow.Bounds.Width / 2 + 50f) && x < (gameWindow.Bounds.Width / 2 + 150f))) //5. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 110f, gameWindow.Height / 2 + 350f), 30f, color.Yellow, 250);

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if ((x > (gameWindow.Bounds.Width / 2 + 150f) && x < (gameWindow.Bounds.Width / 2 + 250f))) //6. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 210f, gameWindow.Height / 2 + 350f), 30f, color.Yellow, 250);

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if ((x > (gameWindow.Bounds.Width / 2 + 250f) && x < (gameWindow.Bounds.Width / 2 + 350f))) //7. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 310f, gameWindow.Height / 2 + 350f), 30f, color.Yellow, 250);

                drawables.Add(circle);
                circles.Add(circle);
            }

            drawables.Sort((j, k) => j.Layer.CompareTo(k.Layer));

            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public void FollowMouse(object o, EventArgs e)
        {
            var mouse = OpenTK.Input.Mouse.GetCursorState();

            float x = mouse.X - gameWindow.Bounds.X;
            float y = gameWindow.Height - (mouse.Y - gameWindow.Bounds.Y);

            circle.Position = new Vector(x - 5f, y + 25f);

            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public void Loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}
