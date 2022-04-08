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
        public const int AFFIRMATIVE_INT = 1;
        public const int NEGATIVE_INT = 2;

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

        public void ChooseGameplay()
        {
            Console.WriteLine("Hello, welcome to Connect 4!");
            Console.WriteLine();

            Console.WriteLine("Do you want to play singleplayer or with 2 players? Enter below.");
            Console.WriteLine();

            Console.WriteLine("If you want to play singleplayer, enter '{0}'. If you want 2 players, enter '{1}'.", AFFIRMATIVE_INT, NEGATIVE_INT);

            int input = Convert.ToInt32(Console.ReadLine());

            do
            {
                if (input == AFFIRMATIVE_INT)
                {
                    PrintIntroSP();
                }
                else if (input == NEGATIVE_INT)
                {
                    PrintIntro();
                }
                else 
                {
                    Console.WriteLine(string.Format("The commands are only '{0}' or '{1}'."), AFFIRMATIVE_INT, NEGATIVE_INT);
                    input = Convert.ToInt32(Console.ReadLine());
                }

            } while (input != 0);
        }

        public void PrintIntroSP()
        {
            Console.WriteLine(string.Format("To get instructions, enter '{0}'.", NEGATIVE_INPUT));
            Console.WriteLine(string.Format("To continue, enter '{0}'.", AFFIRMATIVE_INPUT));

            string input = Console.ReadLine();

            do
            {
                if (input.ToLower() == AFFIRMATIVE_INPUT)
                {
                    Console.WriteLine("You choose singleplayer.");
                    //break;
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

            //ChooseGameplay();
        }
    }
}
