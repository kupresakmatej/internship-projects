using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPXzadatak1
{
    public class Gameplay
    {
        public const string AFFIRMATIVE_INPUT = "y";
        public const string NEGATIVE_INPUT = "x";

        public static readonly Player firstPlayer = new Player();
        public static readonly Player secondPlayer = new Player();
        public static readonly Input inputCommand = new Input();
        //public static readonly Board board = new Board();

        Intro intro = new Intro();
        Logic logic = new Logic();
        Output output = new Output();

        public void Start()
        {
            int columnIdx;
            int helper = 0;

            intro.PrintIntro();

            while (!logic.GameOver())
            {
                inputCommand.InputColumn(helper);

                columnIdx = Convert.ToInt32(inputCommand.ReadColumnInput()) - 1;

                logic.FallIntoPlace(columnIdx, helper);

                Console.WriteLine(Environment.NewLine);
                output.OutputBoard();
                helper++;

                System.Threading.Thread.Sleep(2000);
            }
            Console.Clear();

            output.OutputWinMessage(helper);
            output.OutputBoard();

            System.Threading.Thread.Sleep(5000);

            Restart();
        }

        public void Restart()
        {
            Console.Clear();
            Console.WriteLine(string.Format("If you wish to play again, press '{0}', and if you wish to quit, press '{1}'.", AFFIRMATIVE_INPUT, NEGATIVE_INPUT));
            string restartOrEnd = Console.ReadLine();

            do
            {
                if (restartOrEnd.ToLower() == AFFIRMATIVE_INPUT)
                {
                    Console.Clear();
                    var info = new System.Diagnostics.ProcessStartInfo(Environment.GetCommandLineArgs()[0]);
                    System.Diagnostics.Process.Start(info);

                    Environment.FailFast("");
                }
                else if (restartOrEnd.ToLower() == NEGATIVE_INPUT)
                {
                    Console.Clear();
                    Console.WriteLine("Thanks for playing.");
                    return;
                }
                else
                {
                    Console.WriteLine(string.Format("Enter only '{1}' or '{0}'.", AFFIRMATIVE_INPUT, NEGATIVE_INPUT));
                    restartOrEnd = Console.ReadLine();
                }          
            } while (restartOrEnd != null);

            
        }
    }
}
