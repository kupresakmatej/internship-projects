using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace FPX___Zadatak2
{
    class Board
    {
        private List<Drawable> drawables = new List<Drawable>();
        private List<Quad> quads = new List<Quad>();
        private List<CircleHole> circleHoles = new List<CircleHole>();
        private List<Circle> circles = new List<Circle>();

        Color color = new Color();

        private static GameWindow GameWindow;
        static float aspect;

        Game game = new Game();

        private Circle circle = new Circle(new Vector(0f, 0f), 50f, new Color(0, 255, 0), 250);
        private CircleHole hole;
        private Quad quadS;

        public Board(GameWindow gameWindow)
        {
            GameWindow = gameWindow;
            aspect = GameWindow.Width / gameWindow.Height;       
            hole = new CircleHole(new Vector(GameWindow.Width/2, GameWindow.Height/2), 115f, 70f, new Color(0, 0, 255), 250);
            quadS = new Quad(new Vector(GameWindow.Width / 2, GameWindow.Height / 2), 100f, 100f, new Color(0, 0, 255));
        }

        public List<Drawable> GenerateBoard(float width, float height)
        {
            //for (int i = -4; i < 3; i++)
            //{
            //    for (int j = -3; j < 3; j++)
            //    {
            //        DrawFrame(i * 100f, j * 100f, width, height);
            //        DrawHole(i * 200f, j * 200f, width, height);
            //    }
            //}

            //for (int i = 0; i < 7; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        FillHole(i * 100f, j * 100f, width, height);
            //    }
            //}

            //for (int i = 0; i < 7; i++)
            //{
            //    for (int j = 0; j < 6; j++)
            //    {
            //        FillHoleDown(i * 100f, j * 100f, width, height);
            //    }
            //}

            //for (int i = 0; i < 7; i++)
            //{
            //    FillHoleUp(i * 100f, 0, width, height);
            //}

            drawables.Add(circle);
            drawables.Add(hole);
            drawables.Add(quadS);
            return drawables;
        }

        public void DrawFrame(float x, float y, float widht, float height)
        {
            Quad quad = new Quad(new Vector((widht / 2) + x + 75f, (height / 2) + y), 200f, 40f, color.Blue);
            Quad quad2 = new Quad(new Vector((widht / 2) + x + 75f, (height / 2) + y), 42f, 200f, color.Blue);
            Quad quad3 = new Quad(new Vector((widht / 2 + 100f) + x + 75f, (height / 2) + y), 42f, 200f, color.Blue);
            Quad quad4 = new Quad(new Vector((widht / 2) + x + 75f, (height / 2 + 100f) + y), 242f, 40f, color.Blue);

            drawables.Add(quad);
            drawables.Add(quad2);
            drawables.Add(quad3);
            drawables.Add(quad4);

            quads.Add(quad);
            quads.Add(quad2);
            quads.Add(quad3);
            quads.Add(quad4);

            //Circle circle = new Circle(new Vector(162.5f, 37f), 35f, new Color(255, 255, 0), 250);
        }

        public void DrawHole(float x, float y, float width, float height)
        {
            CircleHole hole = new CircleHole(new Vector(0, 0), 115f, 70f, color.Blue, 250);

            drawables.Add(hole);

            circleHoles.Add(hole);
        }

        public void FillHole(float x, float y, float width, float height)
        {
            Circle circle = new Circle(new Vector((width / 2 - 275f) + x, (height / 2 - 195f) + y), 40f, color.Blue, 250);

            //drawables.Add(circle);

            circles.Add(circle);
        }

        public void FillHoleDown(float x, float y, float width, float height)
        {
            Circle circle = new Circle(new Vector((width / 2 - 300f) + x, (height / 2 - 275f) + y), 25f, color.Blue, 250);

            drawables.Add(circle);

            circles.Add(circle);
        }

        public void FillHoleUp(float x, float y, float width, float height)
        {
            Circle circle = new Circle(new Vector((width / 2 - 275f) + x, (height / 2 + 300f) + y), 25f, color.Blue, 250);

            //drawables.Add(circle);

            circles.Add(circle);
        }

        public void WindowReshape(int width, int height)
        {
            float x = width / 2;
            float y = height / 2;

            circle.Position = new Vector(width / 2, height / 2);

            hole.Position = new Vector(width / 2, height / 2);

            quadS.Position = new Vector(width / 2, height / 2);

            Console.WriteLine("asd");
        }
    }
}