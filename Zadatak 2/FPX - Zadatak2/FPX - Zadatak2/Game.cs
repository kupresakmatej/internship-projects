using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace FPX___Zadatak2
{
    public class Game
    {
        private double theta = 0.0;
        GameWindow gameWindow;

        public Game(GameWindow window)
        {
            this.gameWindow = window;
            Start();
        }

        public void Start()
        {
            gameWindow.Load += Loaded;
            gameWindow.Resize += Resize;
            gameWindow.RenderFrame += RenderF;
            gameWindow.Run(1.0 / 60.0); //time in seconds after which the window updates
        }

        public void Resize(object o, EventArgs e)
        {
            GL.Viewport(0, 0, gameWindow.Width, gameWindow.Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-50.0, 50.0, -50.0, 50.0, -1.0, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void RenderF(object o, EventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Rotate(theta, 0.0, 0.0, 1.0);
            GL.Begin(BeginMode.Quads);

            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex2(30.0, 30.0);
            GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex2(-30.0, 30.0);
            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex2(-30.0, -30.0);
            GL.Color3(1.0, 1.0, 0.0);
            GL.Vertex2(30.0, -30.0);

            GL.End();

            gameWindow.SwapBuffers();

            theta += 1.0; //update se ne radi ovako inace, updateframe funkcija
            if(theta > 360)
            {
                theta -= 360;
            }
        }

        public void Loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}
