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
    class Board : Drawable
    {
        public override int Layer { get => base.Layer; set => base.Layer = value; }
        private Color Color { get; set; }

        public Board(Color color)
        {
            Color = color;
            Layer = 0;
        }

        public override void Draw()
        {
            GL.Translate(0, 0, 0);

            GL.Begin(BeginMode.Quads);

            GL.Color3(Color.R, Color.G, Color.B);   

            GL.Vertex2(0, 0);
            GL.Vertex2(1280, 0);
            GL.Vertex2(1280, 720);
            GL.Vertex2(0, 720);

            GL.End();
        }
    }
}
