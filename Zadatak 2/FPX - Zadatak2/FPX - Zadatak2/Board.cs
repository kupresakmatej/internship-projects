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
        //private List<Quad> quads = new List<Quad>();
        //private List<CircleHole> circleHoles = new List<CircleHole>();
        //private List<Circle> circles = new List<Circle>();

        private List<Quad[]> quadList = new List<Quad[]>();
        private List<CircleHole[]> holeList = new List<CircleHole[]>();

        Color color = new Color();

        private static GameWindow GameWindow;
        static float aspect;

        Game game = new Game();


        public Board(GameWindow gameWindow)
        {
            GameWindow = gameWindow;
            aspect = GameWindow.Width / gameWindow.Height;       
        }

        public List<Drawable> GenerateBoard(float width, float height)
        {
            for(int i = -3; i < 4; i++)
            {
                for(int j = -3; j < 3; j++)
                {
                    DrawFrame(i * 100f, j * 100f, width, height);
                    //DrawHole(i * 100f, j * 100f, width, height);            
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

            //Circle circle = new Circle(new Vector(162.5f, 37f), 35f, new Color(255, 255, 0), 250);
        }

        public void DrawHole(float x, float y, float width, float height)
        {
            CircleHole hole = new CircleHole(new Vector((width/2) + 10f + x, (height/2) + 50f + y), 60f, 35f, color.Blue, 250);

            drawables.Add(hole);
        }

        public void WindowReshape(int width, int height)
        {
            //foreach(Quad[] quad in quadList)
            //{
            //    for(int i = 0; i < quad.Length; i++)
            //    {
            //        quad[i].Position = new Vector((width / 2), (height / 2));
            //    }
            //}

            float pomakX = -400f;
            float pomakY = -200f;

            foreach(Quad[] quad in quadList)
            {
                for(int i = 0; i < 7; i++)
                {
                    quad[0].Position = new Vector((width / 2) + pomakX, (height / 2) + pomakY);
                    quad[1].Position = new Vector((width / 2) - 40f + pomakX, (height / 2) + 50f + pomakY);
                    quad[2].Position = new Vector((width / 2) + 60f + pomakX, (height / 2) + 45f + pomakY);
                    quad[3].Position = new Vector((width / 2) + 10f + pomakX, (height / 2) + 100f + pomakY);
                    pomakX += 15f;
                }
                pomakY += 50f;
            }

            for(int i = 0; i < quadList.Count; i++)
            {

            }

            Console.WriteLine("asd");
        }
    }
}