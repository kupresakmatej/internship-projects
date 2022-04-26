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

            return drawables;
        }

        public void DrawFrame(float x, float y)
        {
            Quad quad = new Quad(new Vector(x + 150f, y + 25f), 110f, 10f, new Color(0, 0, 255));
            Quad quad2 = new Quad(new Vector(x + 150f, y + 25f), 10f, 110f, new Color(0, 0, 255));
            Quad quad3 = new Quad(new Vector(x + 200f, y + 25f), 10f, 110f, new Color(0, 0, 255));
            Quad quad4 = new Quad(new Vector(x + 150f, y + 75f), 110f, 10f, new Color(0, 0, 255));

            drawables.Add(quad);
            drawables.Add(quad2);
            drawables.Add(quad3);
            drawables.Add(quad4);
        }
        
        public void DrawHole(float x, float y)
        {
            CircleHole hole = new CircleHole(new Vector(x + 305f, y + 55f), 50f, 40f, new Color(0, 0, 255), 250);

            drawables.Add(hole);
        }
    }
}
