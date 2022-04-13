using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPX___Zadatak2
{
    class Renderer
    {
        List<Drawable> drawableObjects;

        public Renderer(List<Drawable> objects)
        {
            drawableObjects = objects;
        }

        public void RenderF(object o, EventArgs e)
        {
            foreach(Drawable drawable in drawableObjects)
            {
                drawable.Draw();
            }
        }
    }
}
