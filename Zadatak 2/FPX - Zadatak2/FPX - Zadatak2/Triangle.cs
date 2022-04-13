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

            GL.Begin(BeginMode.Triangles);

            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex2(-A, -A);
            GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex2(A, -A);
            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex2(0, A);

            GL.End();

            //GL.Translate(0.0, 0.0, -45.0);

            gameWindow.SwapBuffers();
        }
    }
}
