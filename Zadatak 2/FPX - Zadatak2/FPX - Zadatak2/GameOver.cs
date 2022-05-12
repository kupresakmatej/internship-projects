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
    class GameOver
    {
        private static List<IRenderable> Drawables;

        private Color color = new Color();

        public GameOver(List<IRenderable> drawables)
        {
            Drawables = drawables;
        }

        public void DrawScene(float width, float height)
        {          
            Quad quad = new Quad(new Vector(width / 2, height / 2), 100f, 100f, color.Red);

            Drawables.Add(quad);
        }
    }
}
