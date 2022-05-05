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

        private Circle circle;

        public Game(GameWindow window)
        {
            this.gameWindow = window;
            drawables = new List<IDrawable>();
            board = new Board(gameWindow);

            circle = new Circle(new Vector(gameWindow.Width/2, gameWindow.Height/2), 50f, new Color(255, 0, 0), 250);

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
            gameWindow.RenderFrame += renderer.RenderF;
            gameWindow.MouseMove += FollowMouse;
            gameWindow.Run(1.0 / 60.0);
        }

        public void Resize(object o, EventArgs e)
        {
            OnResize?.Invoke();

            OnResize += () => board.WindowReshape(gameWindow.Width, gameWindow.Height);

            GL.Viewport(0, 0, gameWindow.Width, gameWindow.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, gameWindow.Width, 0, gameWindow.Height, -1, 1);

            GL.MatrixMode(MatrixMode.Modelview);
        }

        public event Action OnResize;

        public void FollowMouse(object o, EventArgs e)
        {
            var mouse = OpenTK.Input.Mouse.GetCursorState();
            float x = mouse.X;
            float y = gameWindow.Height - mouse.Y;


            circle.Position = new Vector(x, y);
        }

        public void Loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}
