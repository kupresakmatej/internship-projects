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

        private float Width { get; set; }
        private float Height { get; set; }

        Game game = new Game();

        public Board(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public List<Drawable> GenerateBoard()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    DrawFrame(i * 50f, j * 50f);
                    DrawHole(i * 100f, j * 100f);
                }
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    FillHole(i * 50f, j * 50f);
                }
            }

            return drawables;
        }

        public void DrawFrame(float x, float y)
        {
            Quad quad = new Quad(new Vector(x + 150f, y + 25f), 120f, 20f, new Color(0, 0, 255));
            Quad quad2 = new Quad(new Vector(x + 150f, y + 25f), 20f, 110f, new Color(0, 0, 255));
            Quad quad3 = new Quad(new Vector(x + 200f, y + 25f), 20f, 110f, new Color(0, 0, 255));
            Quad quad4 = new Quad(new Vector(x + 150f, y + 75f), 120f, 20f, new Color(0, 0, 255));

            //Circle circle = new Circle(new Vector(162.5f, 37f), 35f, new Color(255, 255, 0), 250);

            drawables.Add(quad);
            drawables.Add(quad2);
            drawables.Add(quad3);
            drawables.Add(quad4);

            quads.Add(quad);
            quads.Add(quad2);
            quads.Add(quad3);
            quads.Add(quad4);
            //drawables.Add(circle);
        }

        public void DrawHole(float x, float y)
        {
            CircleHole hole = new CircleHole(new Vector(x + 300f, y + 50f), 60f, 40f, new Color(0, 0, 255), 250);

            drawables.Add(hole);

            circleHoles.Add(hole);
        }

        public void FillHole(float x, float y)
        {
            Circle circle = new Circle(new Vector(x + 191.5f, y + 66.5f), 26f, new Color(0, 0, 255), 250);

            drawables.Add(circle);

            circles.Add(circle);
        }


        public void WindowReshape(int width, int height)
        {
            foreach (Quad quad in quads)
            {
                quad.Position = new Vector(quad.Position.X, quad.Position.Y);
            }
            foreach (CircleHole hole in circleHoles)
            {
                hole.Position = new Vector(hole.Position.X, hole.Position.Y);
            }
            foreach (Circle circle in circles)
            {
                circle.Position = new Vector(circle.Position.X, circle.Position.Y);
            }

            Console.WriteLine("asdasd");
        }
    }
}