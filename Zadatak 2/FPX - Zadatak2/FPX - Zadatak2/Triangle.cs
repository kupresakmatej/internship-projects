using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace FPX___Zadatak2
{
    class Triangle : IDrawable
    {
        private Vector Position { get; set; }
        private float Size { get; set; }
        private Color Color { get; set; }

        private int layer;
        public int Layer { get { return this.layer; } set { this.layer = value; } }

        public Triangle(Vector position, float size, Color color)
        {
            Position = position;
            Size = size;
            Color = color;
        }

        public void Draw()
        {
            GL.Translate(Position.X, Position.Y, 0.0);
            GL.Begin(BeginMode.Triangles);

            GL.Color3(Color.R, Color.G, Color.B);
            GL.Vertex2(Position.X, Position.Y);
            GL.Vertex2(Position.X + Size, Position.Y);
            GL.Vertex2(Position.X + Size/2, Position.Y + Size);

            GL.End();
        }
    }
}
