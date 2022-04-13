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
        List<Drawable> drawableObjects;

        private static GameWindow gameWindow;

        public Renderer(List<Drawable> objects, GameWindow window)
        {
            drawableObjects = objects;
            gameWindow = window;
        }

        public void RenderF(object o, EventArgs e)
        {
            foreach (Drawable drawable in drawableObjects)
            {
                GL.LoadIdentity();
                drawable.Draw();
            }
            gameWindow.SwapBuffers();
        }
    }
}
