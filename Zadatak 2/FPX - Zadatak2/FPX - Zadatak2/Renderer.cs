using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace FPX___Zadatak2
{
    class Renderer
    {
        List<IDrawable> drawableObjects;

        private static GameWindow gameWindow;

        public Renderer(List<IDrawable> objects, GameWindow window)
        {
            drawableObjects = objects;
            gameWindow = window;
        }

        public void RenderF(object o, EventArgs e)
        {
            foreach (IDrawable drawable in drawableObjects)
            {
                GL.LoadIdentity();
                drawable.Draw();
            }
            gameWindow.SwapBuffers();
        }
    }
}
