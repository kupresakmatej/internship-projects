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
            Console.WriteLine("\nNames saved.");

            System.Threading.Thread.Sleep(5000);
            Console.Clear();

            ChooseColor();

            System.Threading.Thread.Sleep(2000);

            //Gameplay next
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

        public void ChooseColor()
        {
            Console.WriteLine("Now you can choose your coin color, options are - blue, yellow, green and red.\n");
            Console.WriteLine(string.Format("{0}, choose your coin color:", Gameplay.firstPlayer.Name));
            Gameplay.firstPlayer.Color = Console.ReadLine();


            Console.WriteLine(string.Format("\n{0}, choose your coin color:", Gameplay.secondPlayer.Name));
            Gameplay.secondPlayer.Color = Console.ReadLine();
        }
    }
}
