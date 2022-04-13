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
        private double X { get; set; }
        private double Y { get; set; }
        private double Size { get; set; }

        public Triangle(double size, double x, double y)
        {
            X = x;
            Y = y;
            Size = size;
        }

        public override void Draw()
        {
            GL.Translate(X, Y, 0.0);
            GL.Begin(BeginMode.Triangles);

            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex2(-Size, -Size);
            GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex2(Size, -Size);
            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex2(0, Size);

            GL.End();
        }
    }
}
