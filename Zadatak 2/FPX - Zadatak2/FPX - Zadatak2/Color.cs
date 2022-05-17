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
        private float _r;
        private float _g;
        private float _b;

        public float R { 
            get { return _r; } 
            set 
            {
                if (value > 1f)
                    _r = 1f;
                else if (value < 0f)
                    _r = 0f;
                else
                    _r = value;
            } 
        }
        public float G
        {
            get { return _g; }
            set
            {
                if (value > 1f)
                    _g = 1f;
                else if (value < 0f)
                    _g = 0f;
                else
                    _g = value;
            }
        }
        public float B
        {
            get { return _b; }
            set
            {
                if (value > 1f)
                    _b = 1f;
                else if (value < 0f)
                    _b = 0f;
                else
                    _b = value;
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
        public Color Gray { get { return new Color(142, 142, 142); } }

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
