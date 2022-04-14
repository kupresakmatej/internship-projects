using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FPX___Zadatak2
{
    class Colors
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

        public Color RedColor { get { return RedColor; } set { RedColor = Color.FromRgb(255, 0, 0); } }
        public Color GreenColor { get { return GreenColor; } set { GreenColor = Color.FromRgb(0, 255, 0); } }
        public Color BlueColor { get { return BlueColor; } set { BlueColor = Color.FromRgb(0, 0, 255); } }
        public Color YellowColor { get { return YellowColor; } set { YellowColor = Color.FromRgb(255, 255, 0); } }
        public Color FuchsiaColor { get { return FuchsiaColor; } set { FuchsiaColor = Color.FromRgb(255, 0, 255); } }
        public Color CyanColor { get { return CyanColor; } set { CyanColor = Color.FromRgb(0, 255, 255); } }
        public Color BlackColor { get { return BlackColor; } set { BlackColor = Color.FromRgb(0, 0, 0); } }
        public Color WhiteColor { get { return WhiteColor; } set { WhiteColor = Color.FromRgb(255, 255, 255); } }

        public Colors() { }

        public Colors(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Colors(byte[] r, byte[] g, byte[] b)
        {
            R = BitConverter.ToSingle(r, 0);
            G = BitConverter.ToSingle(g, 0);
            B = BitConverter.ToSingle(b, 0);
        }
    }
}
