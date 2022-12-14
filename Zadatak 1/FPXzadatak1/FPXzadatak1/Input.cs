using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPXzadatak1
{
    public class Input
    {
        private static Board board;
        public static readonly string[] COLOR_INPUT = {"blue", "yellow", "green", "red"};

        //public static readonly string[] COLOR_YELLOW = { "blue", "yellow", "green", "red" };
        //public static readonly string[] COLOR_GREEN = { "blue", "yellow", "green", "red" };
        //public static readonly string[] COLOR_RED = { "blue", "yellow", "green", "red" };

        //public static readonly string[] COLUMN_INPUT = { "1", "2", "3", "4", "5", "6", "7" };

        Logic logic = new Logic(board);
        Output output = new Output(board);

        public Input(Board Board)
        {
            board = Board;
        }

        public void InputColumn(int helper, bool isSingePlayer = true)
        {
            if(isSingePlayer)
            {
                output.OutputBoard();
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(string.Format("{0}, enter the number of the column you wish to put your coin in (1 to 7):", Gameplay.firstPlayer.Name));
            }
            else
            {
                if (helper % 2 == 0)
                {
                    output.OutputBoard();
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine(string.Format("{0}, enter the number of the column you wish to put your coin in (1 to 7):", Gameplay.firstPlayer.Name));
                }
                else
                {
                    output.OutputBoard();
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine(string.Format("{0}, enter the number of the column you wish to put your coin in (1 to 7):", Gameplay.secondPlayer.Name));
                }
            }
        }

        public int ReadColumnInput()
        {
            int input;

            do
            {
                input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("You didn't enter a number between 1 and 7. Try again.");

            } while (input < 1 || input > 7);

            return input;
        }

        public void PrintStartInfo(bool isSinglePlayer)
        {
            Console.Clear();
            if(!isSinglePlayer)
                Console.WriteLine("The game has started. It's time to set your player name.");
            else
                Console.WriteLine("The game has started. It's time to set your player names.");

            InputPlayerName(isSinglePlayer);
            Console.WriteLine("\nNames saved.");

            System.Threading.Thread.Sleep(1000);
            Console.Clear();

            ChooseColor(isSinglePlayer);

            System.Threading.Thread.Sleep(1000);

            Console.Clear();
        }

        public void InputPlayerName(bool isSinglePlayer)
        {
            if(!isSinglePlayer)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Player name:");

                Gameplay.firstPlayer.Name = Console.ReadLine();
                Gameplay.secondPlayer.Name = "Computer";
            }
            else
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("First player name:");

                Gameplay.firstPlayer.Name = Console.ReadLine();

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Second player name:");

                Gameplay.secondPlayer.Name = Console.ReadLine();
            }
        }

        public void ChooseColor(bool isSinglePlayer = false)
        {
            Console.WriteLine("Now you can choose your coin color, options are - blue, yellow, green and red.\n");

            Console.WriteLine(string.Format("{0}, choose your coin color:", Gameplay.firstPlayer.Name));
            string firstColor = Console.ReadLine();

            while (!COLOR_INPUT.Any(firstColor.Contains))
            {
                Console.WriteLine("You didn't enter any of the possible colors. Try again.");
                firstColor = Console.ReadLine();
            } 

            if(!isSinglePlayer)
                Console.WriteLine("\nChoose the color for the computer:");
            else
                Console.WriteLine(string.Format("\n{0}, choose your coin color:", Gameplay.secondPlayer.Name));

            string secondColor = Console.ReadLine();

            while (!COLOR_INPUT.Any(secondColor.Contains))
            {
                Console.WriteLine("You didn't enter any of the possible colors. Try again.");
                secondColor = Console.ReadLine();
            }

            Gameplay.firstPlayer.Color = char.ToUpper(firstColor[0]) + firstColor.Substring(1);
            Gameplay.secondPlayer.Color = char.ToUpper(secondColor[0]) + secondColor.Substring(1);
        }
    }
}