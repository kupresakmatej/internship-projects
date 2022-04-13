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
        private double theta = 0.0;

        GameWindow gameWindow;
        private double A { get; set; }

        public Triangle(double a, GameWindow window)
        {
            gameWindow = window;
            A = a;
        }

        public override void Draw()
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Translate(A, 0, 0);

            GL.Begin(BeginMode.Triangles);

            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex2(-A, -A);
            GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex2(A, -A);
            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex2(0, A);

            GL.End();

            gameWindow.SwapBuffers();
        }
    }
}
