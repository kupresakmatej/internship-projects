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
            
        }

        public void PrintStartInfo()
        {
            Console.Clear();
            Console.WriteLine("The game has started. It's time to set your player names.");

            InputPlayerName();
            Console.WriteLine("Names saved.");

            System.Threading.Thread.Sleep(5000);
            Console.Clear();
        }

        public void InputPlayerName()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("First player name:");

            Gameplay.firstPlayer.Name = Console.ReadLine();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Second player name:");

            Gameplay.secondPlayer.Name = Console.ReadLine();
        }
    }
}
