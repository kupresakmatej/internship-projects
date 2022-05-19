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
    class BoardGFX
    {
        private List<IRenderable> drawables = new List<IRenderable>();

        private List<Quad[]> quadList = new List<Quad[]>();
        private List<CircleHole> holeList = new List<CircleHole>();
        public List<Quad[]> p1List = new List<Quad[]>();
        public List<Quad[]> p2List = new List<Quad[]>();
        public List<Quad[]> winList = new List<Quad[]>();
        public List<Quad[]> buttonList = new List<Quad[]>();

        private static GameWindow GameWindow;

        Color color = new Color();

        float w;
        float h;

        public BoardGFX(GameWindow gameWindow)
        {
            GameWindow = gameWindow;
        }

        public List<IRenderable> GenerateBoard(float width, float height)
        {
            w = width / 2;
            h = height / 2;

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

        public void DrawPlayers(float width, float height, Color p1Color, Color p2Color)
        {
            //players
            Quad[] p1Quads = new Quad[5];
            Quad[] p2Quads = new Quad[9];

            Quad p1_quad_1 = new Quad(new Vector(width / 2 - 500f, height / 2 - 210f), 30f, 200f, p1Color);

            Quad p1_quad_2 = new Quad(new Vector(width / 2 - 535f, height / 2 + 210f), 30f, 200f, p1Color);
            Quad p1_quad_3 = new Quad(new Vector(width / 2 - 435f, height / 2 + 270f), 30f, 80f, p1Color);
            Quad p1_quad_4 = new Quad(new Vector(width / 2 - 470f, height / 2 + 215f), 100f, 30f, p1Color);
            Quad p1_quad_5 = new Quad(new Vector(width / 2 - 470f, height / 2 + 295f), 100f, 30f, p1Color);

            p1Quads[0] = p1_quad_1;
            p1Quads[1] = p1_quad_2;
            p1Quads[2] = p1_quad_3;
            p1Quads[3] = p1_quad_4;
            p1Quads[4] = p1_quad_5;
            p1List.Add(p1Quads);

            Quad p2_quad_1 = new Quad(new Vector(width / 2 + 435f, height / 2 + 210f), 30f, 200f, p2Color);
            Quad p2_quad_2 = new Quad(new Vector(width / 2 + 535f, height / 2 + 270f), 30f, 80f, p2Color);
            Quad p2_quad_3 = new Quad(new Vector(width / 2 + 500f, height / 2 + 215f), 100f, 30f, p2Color);
            Quad p2_quad_4 = new Quad(new Vector(width / 2 + 480f, height / 2 + 295f), 100f, 30f, p2Color);

            Quad p2_quad_5 = new Quad(new Vector(width / 2 + 490f, height / 2 - 95f), 120f, 30f, p2Color);
            Quad p2_quad_6 = new Quad(new Vector(width / 2 + 535f, height / 2 - 130f), 30f, 100f, p2Color);
            Quad p2_quad_7 = new Quad(new Vector(width / 2 + 490f, height / 2 - 195f), 120f, 30f, p2Color);
            Quad p2_quad_8 = new Quad(new Vector(width / 2 + 445f, height / 2 - 230f), 30f, 100f, p2Color);
            Quad p2_quad_9 = new Quad(new Vector(width / 2 + 490f, height / 2 - 295f), 120f, 30f, p2Color);

            p2Quads[0] = p2_quad_1;
            p2Quads[1] = p2_quad_2;
            p2Quads[2] = p2_quad_3;
            p2Quads[3] = p2_quad_4;
            p2Quads[4] = p2_quad_5;
            p2Quads[5] = p2_quad_6;
            p2Quads[6] = p2_quad_7;
            p2Quads[7] = p2_quad_8;
            p2Quads[8] = p2_quad_9;
            p2List.Add(p2Quads);

            drawables.Add(p1_quad_1);
            drawables.Add(p1_quad_2);
            drawables.Add(p1_quad_3);
            drawables.Add(p1_quad_4);
            drawables.Add(p1_quad_5);

            drawables.Add(p2_quad_1);
            drawables.Add(p2_quad_2);
            drawables.Add(p2_quad_3);
            drawables.Add(p2_quad_4);

            drawables.Add(p2_quad_5);
            drawables.Add(p2_quad_6);
            drawables.Add(p2_quad_7);
            drawables.Add(p2_quad_8);
            drawables.Add(p2_quad_9);
        }

        public void DrawFrame(float x, float y, float width, float height)
        {
            Quad[] quads = new Quad[4];

            Quad quad = new Quad(new Vector((width / 2 - 10f) + x, (height / 2) + y), 100f, 20f, color.Blue);
            Quad quad2 = new Quad(new Vector((width / 2 - 10f) + x - 40f, (height / 2) + y + 50f), 20f, 100f, color.Blue);
            Quad quad3 = new Quad(new Vector((width / 2 + 50f) + x, (height / 2) + y + 45f), 20f, 110f, color.Blue);
            Quad quad4 = new Quad(new Vector((width / 2 - 10f) + x + 10f, (height / 2 + 100f) + y), 120f, 20f, color.Blue);

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
            CircleHole hole = new CircleHole(new Vector((width / 2 - 10f) + 10f + x, (height / 2) + 50f + y), 60f, 35f, color.Blue, 250);

            drawables.Add(hole);

            holeList.Add(hole);
        }

        public void WindowReshape(int width, int height, List<Circle> circles)
        {
            foreach (Quad[] quad in quadList)
            {
                if (width < w)
                {
                    for(int i = 0; i < quad.Length; i++)
                    {
                        quad[i].Position = new Vector(quad[i].Position.X + (width / 2 - w), quad[i].Position.Y);
                    }
                }
                if (width > w)
                {
                    for (int i = 0; i < quad.Length; i++)
                    {
                        quad[i].Position = new Vector(quad[i].Position.X + (width / 2 - w), quad[i].Position.Y);
                    }
                }
                if (height < h)
                {
                    for (int i = 0; i < quad.Length; i++)
                    {
                        quad[i].Position = new Vector(quad[i].Position.X, quad[i].Position.Y + (height / 2 - h));
                    }
                }
                if (height > h)
                {
                    for (int i = 0; i < quad.Length; i++)
                    {
                        quad[i].Position = new Vector(quad[i].Position.X, quad[i].Position.Y + (height / 2 - h));
                    }
                }
            }

            foreach (CircleHole hole in holeList)
            {
                if (width < w)
                {
                    hole.Position = new Vector(hole.Position.X + (width / 2 - w), hole.Position.Y);
                }
                if (width > w)
                {
                    hole.Position = new Vector(hole.Position.X + (width / 2 - w), hole.Position.Y);
                }
                if (height < h)
                {
                    hole.Position = new Vector(hole.Position.X, hole.Position.Y + (height / 2 - h));
                }
                if (height > h)
                {
                    hole.Position = new Vector(hole.Position.X, hole.Position.Y + (height / 2 - h));
                }
            }

            foreach (Circle circle in circles)
            {
                if (width < w)
                {
                    circle.Position = new Vector(circle.Position.X + (width / 2 - w), circle.Position.Y);
                }
                if (width > w)
                {
                    circle.Position = new Vector(circle.Position.X + (width / 2 - w), circle.Position.Y);
                }
                if (height < h)
                {
                    circle.Position = new Vector(circle.Position.X, circle.Position.Y + (height / 2 - h));
                }
                if (height > h)
                {
                    circle.Position = new Vector(circle.Position.X, circle.Position.Y + (height / 2 - h));
                }
            }

            foreach (Quad[] quad in p2List)
            {
                if (width < w)
                {
                    for(int i = 0; i < quad.Length; i++)
                    {
                        quad[i].Position = new Vector(quad[i].Position.X + (width / 2 - w), quad[i].Position.Y);
                    }
                }
                if (width > w)
                {
                    for (int i = 0; i < quad.Length; i++)
                    {
                        quad[i].Position = new Vector(quad[i].Position.X + (width / 2 - w), quad[i].Position.Y);
                    }
                }
                if (height < h)
                {
                    for (int i = 0; i < quad.Length; i++)
                    {
                        quad[i].Position = new Vector(quad[i].Position.X, quad[i].Position.Y + (height / 2 - h));
                    }
                }
                if (height > h)
                {
                    for (int i = 0; i < quad.Length; i++)
                    {
                        quad[i].Position = new Vector(quad[i].Position.X, quad[i].Position.Y + (height / 2 - h));
                    }
                }
            }

            foreach (Quad[] quad in p1List)
            {
                if (width < w)
                {
                    for(int i = 0; i < quad.Length; i++)
                    {
                        quad[i].Position = new Vector(quad[i].Position.X + (width / 2 - w), quad[i].Position.Y);
                    }
                }
                if (width > w)
                {
                    for (int i = 0; i < quad.Length; i++)
                    {
                        quad[i].Position = new Vector(quad[i].Position.X + (width / 2 - w), quad[i].Position.Y);
                    }
                }
                if (height < h)
                {
                    for (int i = 0; i < quad.Length; i++)
                    {
                        quad[i].Position = new Vector(quad[i].Position.X, quad[i].Position.Y + (height / 2 - h));
                    }
                }
                if (height > h)
                {
                    
                    for(int i = 0; i < quad.Length; i++)
                    {
                        quad[i].Position = new Vector(quad[i].Position.X, quad[i].Position.Y + (height / 2 - h));
                    }
                }
            }

            foreach (Quad[] quad in winList)
            {
                if (width < w)
                {
                    for(int i = 0; i < quad.Length; i++)
                    {
                        quad[i].Position = new Vector(quad[i].Position.X + (width / 2 - w), quad[i].Position.Y);
                    }
                }
                if (width > w)
                {
                    for (int i = 0; i < quad.Length; i++)
                    {
                        quad[i].Position = new Vector(quad[i].Position.X + (width / 2 - w), quad[i].Position.Y);
                    }
                }
                if (height < h)
                {
                    for (int i = 0; i < quad.Length; i++)
                    {
                        quad[i].Position = new Vector(quad[i].Position.X, quad[i].Position.Y + (height / 2 - h));
                    }
                }
                if (height > h)
                {
                    for (int i = 0; i < quad.Length; i++)
                    {
                        quad[i].Position = new Vector(quad[i].Position.X, quad[i].Position.Y + (height / 2 - h));
                    }
                }
            }

            foreach (Quad[] quad in buttonList)
            {
                if (width < w)
                {
                    quad[0].Position = new Vector(quad[0].Position.X + (width / 2 - w), quad[0].Position.Y);
                    quad[1].Position = new Vector(quad[1].Position.X + (width / 2 - w), quad[1].Position.Y);
                }
                if (width > w)
                {
                    quad[0].Position = new Vector(quad[0].Position.X + (width / 2 - w), quad[0].Position.Y);
                    quad[1].Position = new Vector(quad[1].Position.X + (width / 2 - w), quad[1].Position.Y);
                }
                if (height < h)
                {
                    quad[0].Position = new Vector(quad[0].Position.X, quad[0].Position.Y + (height / 2 - h));
                    quad[1].Position = new Vector(quad[1].Position.X, quad[1].Position.Y + (height / 2 - h));
                }
                if (height > h)
                {
                    quad[0].Position = new Vector(quad[0].Position.X, quad[0].Position.Y + (height / 2 - h));
                    quad[1].Position = new Vector(quad[1].Position.X, quad[1].Position.Y + (height / 2 - h));
                }
            }

            w = width / 2;
            h = height / 2;
        }
    }
}
