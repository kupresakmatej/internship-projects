using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPX___Zadatak2
{
    abstract class Drawable
    {
        private int _layer;
        public virtual int Layer 
        { 
            get 
            { 
                return _layer; 
            } 
            set
            {
                if (value < 0)
                    _layer = 0;
                else
                    _layer = value;
            }
        }
        public abstract void Draw();
    }
}
