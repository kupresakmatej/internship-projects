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
    class Quad : Drawable
    {
        public Vector Position { get; set; }
        private float A { get; set; }
        private float B { get; set; }
        private Color Color { get; set; }
        public override int Layer { get => base.Layer; set => base.Layer = value; }

        public Quad(Vector position, float a, float b, Color color)
        {
            Position = position;
            A = a;
            B = b;
            Color = color;
            Layer = 1;
        }

        public override void Draw()
        {
            GL.Translate(Position.X, Position.Y, 0.0);

            GL.Begin(BeginMode.Quads);

            GL.Color3(Color.R, Color.G, Color.B);

            GL.Vertex2(Position.X, Position.Y);
            GL.Vertex2(Position.X + A, Position.Y);
            GL.Vertex2(Position.X + A, Position.Y + B);
            GL.Vertex2(Position.X, Position.Y + B);

            GL.End();
        }
    }
}
