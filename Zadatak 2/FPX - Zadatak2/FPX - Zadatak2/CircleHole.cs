using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace FPX___Zadatak2
{
    class CircleHole : Drawable
    {
        private Vector Position { get; set; }
        private float RadiusOut { get; set; }
        private float RadiusIn { get; set; }
        private Color Color { get; set; }
        private int AmountOfTriangles { get; set; }
        public override int Layer { get => base.Layer; set => base.Layer = value; }

        public CircleHole(Vector position, float radiusOut, float radiusIn, Color color, int amountOfTriangles)
        {
            Position = position;
            RadiusOut = radiusOut;
            RadiusIn = radiusIn;
            Color = color;
            AmountOfTriangles = amountOfTriangles;
            Layer = 1;
        }

        public override void Draw()
        {
            GL.Translate(Position.X + RadiusOut, Position.Y + RadiusOut, 0.0);

            GL.Color3(Color.R, Color.G, Color.B);
            GL.Vertex2(Position.X, Position.Y);

            GL.Begin(BeginMode.QuadStrip);
            
            for (int i = 0; i <= AmountOfTriangles; i++)
            {
                float angle = (i / (float)AmountOfTriangles) * 3.14159f * 2f;
                GL.Vertex2(RadiusIn * Math.Cos(angle), RadiusIn * Math.Sin(angle));
                GL.Vertex2(RadiusOut * Math.Cos(angle), RadiusOut * Math.Sin(angle));
            }
            GL.End();
        }
    }
}
