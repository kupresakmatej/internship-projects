﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPXzadatak1
{
    public class Input
    {
        private static Board board = new Board();
        public static readonly string[] COLOR_INPUT = {"blue", "yellow", "green", "red"};
        public static readonly string[] COLUMN_INPUT = { "1", "2", "3", "4", "5", "6", "7" };

        Logic logic = new Logic(board);
        Output output = new Output();

        public void InputColumn(int helper)
        {
            if(helper % 2 == 0)
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

        public string ReadColumnInput()
        {
            string input;

            do
            {
                input = Console.ReadLine();
                Console.WriteLine("You didn't enter a number between 1 and 7. Try again.");

            } while (!COLUMN_INPUT.Any(input.Contains));
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

        public void ChooseColor()
        {
            Console.WriteLine("Now you can choose your coin color, options are - blue, yellow, green and red.\n");

            Console.WriteLine(string.Format("{0}, choose your coin color:", Gameplay.firstPlayer.Name));
            string firstColor;

            do
            {
                firstColor = Console.ReadLine();
                Console.WriteLine("You didn't enter any of the possible colors. Try again.");

            } while (!COLOR_INPUT.Any(firstColor.Contains));


            Console.WriteLine(string.Format("\n{0}, choose your coin color:", Gameplay.secondPlayer.Name));
            string secondColor;

            do
            {
                secondColor = Console.ReadLine();
                Console.WriteLine("You didn't enter any of the possible colors. Try again.");

            } while (!COLOR_INPUT.Any(secondColor.Contains));

            Gameplay.firstPlayer.Color = char.ToUpper(firstColor[0]) + firstColor.Substring(1);
            Gameplay.secondPlayer.Color = char.ToUpper(secondColor[0]) + secondColor.Substring(1);
        }
    }
}