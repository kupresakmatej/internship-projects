using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FPX___Zadatak2
{
    class Color
    {
        public float R { 
            get { return R; }
            
            set 
            {
                if(value < 0 || value > 1)
                {
                    R = 1f;
                }
            } 
        }
        public float G
        {
            get { return G; }

            set
            {
                if (value < 0 || value > 1)
                {
                    G = 1f;
                }
            }
        }
        public float B
        {
            get { return B; }

            set
            {
                if (value < 0 || value > 1)
                {
                    B = 1f;
                }
            }
        }

        public Color Red { get { return new Color(255, 0, 0); } }
        public Color Green { get { return new Color(0, 255, 0); } }
        public Color Blue { get { return new Color(0, 0, 255); } }
        public Color Yellow { get { return new Color(255, 255, 0); } }
        public Color Fuchsia { get { return new Color(255, 0, 255); } }
        public Color Cyan { get { return new Color(0, 255, 255); } }
        public Color Black { get { return new Color(0, 0, 0); } }
        public Color White { get { return new Color(255, 255, 255); }  }

        public Color() { }

        public Color(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Color(byte r, byte g, byte b)
        {
            R = (float)r / 255.0f;
            G = (float)g / 255.0f;
            B = (float)b / 255.0f;
        }
    }
}
