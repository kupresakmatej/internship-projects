using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPXzadatak1
{
    internal class Intro
    {
        public const string AFFIRMATIVE_INPUT = "y";
        public const string NEGATIVE_INPUT = "x";

        Input inputClass = new Input();

        public void PrintIntro()
        {
            Console.WriteLine("Hello, welcome to Connect 4!");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(string.Format("To get instructions, enter '{0}'.", NEGATIVE_INPUT));
            Console.WriteLine(string.Format("To continue, enter '{0}'.", AFFIRMATIVE_INPUT));

            string input = Console.ReadLine();

            do
            {
                if (input.ToLower() == AFFIRMATIVE_INPUT)
                {
                    inputClass.PrintStartInfo();
                    break;
                }
                else if (input.ToLower() == NEGATIVE_INPUT)
                {
                    PrintInstructions();
                    break;
                }
                else
                {
                    Console.WriteLine("The commands are only 'x' or 'y'. Try again.");
                    input = Console.ReadLine();
                }
            } while (input != null);
        }

        public void PrintInstructions()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Your goal is to connect 4 coins in a row, column or diagonally.");
            Console.WriteLine("You will be entering the number of the column you want to put your coin in.");

            System.Threading.Thread.Sleep(5000);

            inputClass.InputColumn();
        }
    }
}
