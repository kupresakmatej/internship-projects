using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPX___Zadatak2
{
    interface IDrawable
    {
        int Layer { get; set; }
        void Draw();
    }
}
