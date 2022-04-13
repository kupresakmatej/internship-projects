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
        private double A { get; set; }

        public Triangle(double a)
        {
            A = a;
        }

        public override void Draw()
        {
            GL.Translate(0.0, 0.0, 0.0);
            GL.Begin(BeginMode.Triangles);

            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex2(-A, -A);
            GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex2(A, -A);
            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex2(0, A);

            GL.End();
        }
    }
}
