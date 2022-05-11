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
        List<IRenderable> drawableObjects;

        private static GameWindow gameWindow;

        public Renderer(List<IRenderable> objects, GameWindow window)
        {
            drawableObjects = objects;
            gameWindow = window;
        }

        public void RenderF(object o, EventArgs e)
        {
            foreach (IRenderable drawable in drawableObjects)
            {
                GL.LoadIdentity();
                drawable.Draw();
            }
            gameWindow.SwapBuffers();
        }
    }
}
