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
        public const string AFFIRMATIVE_INT = "1";
        public const string NEGATIVE_INT = "2";

        private static Board board;

        public Intro(Board Board)
        {
            board = Board;
        }

        Input inputClass = new Input(board);

        public void PrintIntro()
        {
            Console.Clear();
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
                    Console.WriteLine(string.Format("The commands are only '{0}' or '{1}'. Try again."), AFFIRMATIVE_INPUT, NEGATIVE_INPUT);
                    input = Console.ReadLine();
                }
            } while (input != null);
        }

        public void ChooseGameplay(string input)
        {
            if (input.ToLower() == AFFIRMATIVE_INT)
            {
                PrintIntroSP();
            }
            else if (input.ToLower() == NEGATIVE_INT)
            {
                PrintIntro();
            }
            else
            {
                Console.WriteLine(string.Format("The commands are only '{0}' or '{1}'."), AFFIRMATIVE_INT, NEGATIVE_INT);
                input = Console.ReadLine();
            }
        }

        public void PrintIntroSP()
        {
            Console.Clear();
            Console.WriteLine(string.Format("To get instructions, enter '{0}'.", NEGATIVE_INPUT));
            Console.WriteLine(string.Format("To continue, enter '{0}'.", AFFIRMATIVE_INPUT));

            string input = Console.ReadLine();

            do
            {
                if (input.ToLower() == AFFIRMATIVE_INPUT)
                {
                    inputClass.PrintStartInfoSP();
                    break;
                }
                else if (input.ToLower() == NEGATIVE_INPUT)
                {
                    PrintInstructionsSP();
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

            inputClass.PrintStartInfo();
        }

        public void PrintInstructionsSP()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Your goal is to connect 4 coins in a row, column or diagonally.");
            Console.WriteLine("You will be entering the number of the column you want to put your coin in.");

            System.Threading.Thread.Sleep(5000);

            inputClass.PrintStartInfoSP();
        }
    }
}
