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
            Gameplay.firstPlayer.Color = Console.ReadLine();

            do
            {
                Console.WriteLine("You didn't enter any of the possible colors. Try again.");
                Gameplay.firstPlayer.Color = Console.ReadLine();

            } while (!COLOR_INPUT.Contains(Gameplay.firstPlayer.Color.ToLower()));


            Console.WriteLine(string.Format("\n{0}, choose your coin color:", Gameplay.secondPlayer.Name));
            Gameplay.secondPlayer.Color = Console.ReadLine();

            do
            {
                Console.WriteLine("You didn't enter any of the possible colors. Try again.");
                Gameplay.secondPlayer.Color = Console.ReadLine();

            } while (!COLOR_INPUT.Contains(Gameplay.secondPlayer.Color.ToLower()));
           
        }

        public void Output()
        {
            int rowLength = Logic.Instance.BoardLayout.GetLength(0);
            int columnLength = Logic.Instance.BoardLayout.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    if (Logic.Instance.BoardLayout[i, j] != null)
                    {
                        if(Logic.Instance.BoardLayout[i, j].Color == "blue")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if (Logic.Instance.BoardLayout[i, j].Color == "yellow")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else if (Logic.Instance.BoardLayout[i, j].Color == "green")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (Logic.Instance.BoardLayout[i, j].Color == "red")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }

                        Console.Write(string.Format("1 "));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(string.Format("0 "));
                    }
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
