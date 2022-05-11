using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace FPX___Zadatak2
{
    class Circle : IRenderable
    {
        public Vector Position { get; set; }
        private float Radius { get; set; }
        private Color Color { get; set; }
        private int AmountOfTriangles { get; set; }

        private int layer;
        public int Layer { get { return this.layer; } set { this.layer = value; } }

        public Circle(Vector position, float radius, Color color, int amountOfTriangles)
        {
            Position = position;
            Radius = radius;
            Color = color;
            AmountOfTriangles = amountOfTriangles;
            Layer = 0;
        }

        public Circle()
        {
            
        }

        public void Draw()
        {
            GL.Begin(BeginMode.TriangleFan);

            GL.Color3(Color.R, Color.G, Color.B);
            GL.Vertex2(Position.X, Position.Y);

            for (int i = 0; i <= AmountOfTriangles; i++)
            {
                GL.Vertex2(Position.X + (Radius * Math.Cos(i * (2 * Math.PI) / AmountOfTriangles)), Position.Y + (Radius * Math.Sin(i * (2 * Math.PI) / AmountOfTriangles)));
            }

            GL.End();
        }
    }
}
