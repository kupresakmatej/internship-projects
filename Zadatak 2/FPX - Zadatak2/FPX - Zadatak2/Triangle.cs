using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace FPX___Zadatak2
{
    class Triangle : Drawable
    {
        private float X { get; set; }
        private float Y { get; set; }
        private float Size { get; set; }
        private Color Color { get; set; }

        public Triangle(Vector vector, float size, Color color)
        {
            X = vector.X;
            Y = vector.Y;
            Size = size;
            Color = color;
        }

        public override void Draw()
        {
            GL.Translate(X, Y, 0.0);
            GL.Begin(BeginMode.Triangles);

            GL.Color3(Color.R, Color.G, Color.B);
            GL.Vertex2(X, Y);
            GL.Vertex2(X + Size, Y);
            GL.Vertex2(X + Size/2, Y + Size);

            GL.End();
        }
    }
}
