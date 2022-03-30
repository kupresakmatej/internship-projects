using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPXzadatak1
{
    public class Input
    {
        public static readonly string[] COLOR_INPUT = {"blue", "yellow", "green", "red"};

        Logic logic = new Logic();

        public void InputColumn(int helper)
        {
            Console.Clear();

            if(helper % 2 == 0)
            {
                Console.WriteLine(string.Format("{0}, enter the number of the column you wish to put your coin in (1 to 7):", Gameplay.firstPlayer.Name));
            }
            else
            {
                Console.WriteLine(string.Format("{0}, enter the number of the column you wish to put your coin in (1 to 7):", Gameplay.secondPlayer.Name));
            }
        }

        public string ReadColumnInput()
        {
            string input;

            input = Console.ReadLine();

            return input;
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
            string firstColor = Console.ReadLine();

            do
            {
                Console.WriteLine("You didn't enter any of the possible colors. Try again.");
                firstColor = Console.ReadLine();

            } while (!COLOR_INPUT.Any(firstColor.Contains));


            Console.WriteLine(string.Format("\n{0}, choose your coin color:", Gameplay.secondPlayer.Name));
            string secondColor = Console.ReadLine();

            do
            {
                Console.WriteLine("You didn't enter any of the possible colors. Try again.");
                secondColor = Console.ReadLine();

            } while (!COLOR_INPUT.Any(secondColor.Contains));

            Gameplay.firstPlayer.Color = char.ToUpper(firstColor[0]) + firstColor.Substring(1);
            Gameplay.secondPlayer.Color = char.ToUpper(secondColor[0]) + secondColor.Substring(1);
        }
    }
}