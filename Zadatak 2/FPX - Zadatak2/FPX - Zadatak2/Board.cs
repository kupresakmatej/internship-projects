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

        public Board()
        {

        }

        public List<Drawable> DrawBoard()
        {
            for(int i = 0; i < 7; i++)
            {
                
                for(int j = 0; j < 6; j++)
                {
                    DrawFrame(i * 50f, j * 50f);
                    DrawHole(i * 100f, j * 100f);
                }
            }

            for(int i = 0; i < 6; i++)
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
            Quad quad = new Quad(new Vector(x + 150f, y + 25f), 118f, 18f, new Color(0, 0, 255));
            Quad quad2 = new Quad(new Vector(x + 150f, y + 25f), 18f, 110f, new Color(0, 0, 255));
            Quad quad3 = new Quad(new Vector(x + 200f, y + 25f), 18f, 110f, new Color(0, 0, 255));
            Quad quad4 = new Quad(new Vector(x + 150f, y + 75f), 118f, 18f, new Color(0, 0, 255));

            //Circle circle = new Circle(new Vector(162.5f, 37f), 35f, new Color(255, 255, 0), 250);

            drawables.Add(quad);
            drawables.Add(quad2);
            drawables.Add(quad3);
            drawables.Add(quad4);
            //drawables.Add(circle);
        }
        
        public void DrawHole(float x, float y)
        {
            CircleHole hole = new CircleHole(new Vector(x + 300f, y + 50f), 59f, 40f, new Color(0, 0, 255), 250);

            drawables.Add(hole);
        }

        public void FillHole(float x, float y)
        {
            Circle circle = new Circle(new Vector(x + 191.5f, y + 66.5f), 26f, new Color(0, 0, 255), 250);

            drawables.Add(circle);
        }
    }
}
