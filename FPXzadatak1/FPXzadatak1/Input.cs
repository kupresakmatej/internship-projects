using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPXzadatak1
{
    public class Input
    {
        Logic logic = new Logic();

        public void InputColumn()
        {
            PrintStartInfo();
        }

        public void PrintStartInfo()
        {
            Console.Clear();
            Console.WriteLine("The game has started. It's time to get your input.");
        }
    }
}
