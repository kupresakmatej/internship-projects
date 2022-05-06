using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;

namespace FPX___Zadatak2
{
    class Board
    {
        private List<IDrawable> drawables = new List<IDrawable>();

        private List<Quad[]> quadList = new List<Quad[]>();
        private List<CircleHole> holeList = new List<CircleHole>();

        private static GameWindow GameWindow;

        Game game = new Game();
        Color color = new Color();

        float w;
        float h;

        public Board(GameWindow gameWindow)
        {
            GameWindow = gameWindow;  
        }

        public List<IDrawable> GenerateBoard(float width, float height)
        {
            w = width;
            h = height;

            for (int i = -3; i < 4; i++)
            {
                for (int j = -3; j < 3; j++)
                {
                    DrawFrame(i * 100f, j * 100f, width, height);
                    DrawHole(i * 100f, j * 100f, width, height);
                }
            }

            return drawables;
        }

        public void DrawFrame(float x, float y, float width, float height)
        {
            Quad[] quads = new Quad[4];

            Quad quad = new Quad(new Vector((width / 2) + x, (height / 2) + y), 100f, 20f, color.Blue);
            Quad quad2 = new Quad(new Vector((width / 2) + x - 40f, (height / 2) + y + 50f), 20f, 100f, color.Blue);
            Quad quad3 = new Quad(new Vector((width / 2 + 60f) + x, (height / 2) + y + 45f), 20f, 110f, color.Blue);
            Quad quad4 = new Quad(new Vector((width / 2) + x + 10f, (height / 2 + 100f) + y), 120f, 20f, color.Blue);

            drawables.Add(quad);
            drawables.Add(quad2);
            drawables.Add(quad3);
            drawables.Add(quad4);

            quads[0] = quad;
            quads[1] = quad2;
            quads[2] = quad3;
            quads[3] = quad4;

            quadList.Add(quads);
        }

        public void DrawHole(float x, float y, float width, float height)
        {
            CircleHole hole = new CircleHole(new Vector((width/2) + 10f + x, (height/2) + 50f + y), 60f, 35f, color.Blue, 250);

            drawables.Add(hole);

            holeList.Add(hole);
        }

        public void WindowReshape(int width, int height, List<Circle> circles)
        {
            foreach (Quad[] quad in quadList)
            {
                if(width < w)
                {
                    quad[0].Position = new Vector(quad[0].Position.X + (width / 2 - w / 2), quad[0].Position.Y);
                    quad[1].Position = new Vector(quad[1].Position.X + (width / 2 - w / 2), quad[1].Position.Y);
                    quad[2].Position = new Vector(quad[2].Position.X + (width / 2 - w / 2), quad[2].Position.Y);
                    quad[3].Position = new Vector(quad[3].Position.X + (width / 2 - w / 2), quad[3].Position.Y);
                }
                if(width > w)
                {
                    quad[0].Position = new Vector(quad[0].Position.X + (width / 2 - w / 2), quad[0].Position.Y);
                    quad[1].Position = new Vector(quad[1].Position.X + (width / 2 - w / 2), quad[1].Position.Y);
                    quad[2].Position = new Vector(quad[2].Position.X + (width / 2 - w / 2), quad[2].Position.Y);
                    quad[3].Position = new Vector(quad[3].Position.X + (width / 2 - w / 2), quad[3].Position.Y);
                }
                if (height < h)
                {
                    quad[0].Position = new Vector(quad[0].Position.X, quad[0].Position.Y + (height / 2 - h / 2));
                    quad[1].Position = new Vector(quad[1].Position.X, quad[1].Position.Y + (height / 2 - h / 2));
                    quad[2].Position = new Vector(quad[2].Position.X, quad[2].Position.Y + (height / 2 - h / 2));
                    quad[3].Position = new Vector(quad[3].Position.X, quad[3].Position.Y + (height / 2 - h / 2));
                }
                if (height > h)
                {
                    quad[0].Position = new Vector(quad[0].Position.X, quad[0].Position.Y + (height / 2 - h / 2));
                    quad[1].Position = new Vector(quad[1].Position.X, quad[1].Position.Y + (height / 2 - h / 2));
                    quad[2].Position = new Vector(quad[2].Position.X, quad[2].Position.Y + (height / 2 - h / 2));
                    quad[3].Position = new Vector(quad[3].Position.X, quad[3].Position.Y + (height / 2 - h / 2));
                }
            }

            foreach (CircleHole hole in holeList)
            {
                if(width < w)
                {
                    hole.Position = new Vector(hole.Position.X + (width / 2 - w / 2), hole.Position.Y);
                }
                if(width > w)
                {
                    hole.Position = new Vector(hole.Position.X + (width / 2 - w / 2), hole.Position.Y);
                }
                if(height < h)
                {
                    hole.Position = new Vector(hole.Position.X, hole.Position.Y + (height / 2 - h / 2));
                }
                if (height > h)
                {
                    hole.Position = new Vector(hole.Position.X, hole.Position.Y + (height / 2 - h / 2));
                }
            }

            foreach (Circle circle in circles)
            {
                if (width < w)
                {
                    circle.Position = new Vector(circle.Position.X + (width / 2 - w / 2), circle.Position.Y);
                }
                if (width > w)
                {
                    circle.Position = new Vector(circle.Position.X + (width / 2 - w / 2), circle.Position.Y);
                }
                if (height < h)
                {
                    circle.Position = new Vector(circle.Position.X, circle.Position.Y + (height / 2 - h / 2));
                }
                if (height > h)
                {
                    circle.Position = new Vector(circle.Position.X, circle.Position.Y + (height / 2 - h / 2));
                }
            }

            w = width;
            h = height;
        }
    }
}