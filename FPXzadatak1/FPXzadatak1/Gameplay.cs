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
        public const string AFFIRMATIVE_INT = "1";
        public const string NEGATIVE_INT = "2";

        public static readonly Player firstPlayer = new Player();
        public static readonly Player secondPlayer = new Player();
        public static readonly Input inputCommand = new Input(board);
        private static Board board = new Board();

        Intro intro = new Intro(board);
        Logic logic = new Logic(board);
        Output output = new Output(board);

        public void Start()
        {
            board.FillBoard();

            Console.WriteLine("Hello, welcome to Connect 4!");
            Console.WriteLine();

            Console.WriteLine("Do you want to play singleplayer or with 2 players? Enter below.");
            Console.WriteLine();

            Console.WriteLine("If you want to play singleplayer, enter '{0}'. If you want 2 players, enter '{1}'.", AFFIRMATIVE_INT, NEGATIVE_INT);

            string input = Console.ReadLine();

            intro.ChooseGameplay(input);

            if(input == AFFIRMATIVE_INT)
            {
                Singleplayer();
            }
            if(input == NEGATIVE_INT)
            {
                Multiplayer();
            }
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

        public void Singleplayer()
        {
            int columnIdx;
            int helper = 0;

            while(!logic.GameOver())
            {
                inputCommand.InputColumnSP();

                columnIdx = Convert.ToInt32(inputCommand.ReadColumnInput()) - 1;

                logic.FallIntoPlaceSP(columnIdx);

                Console.WriteLine(Environment.NewLine);
                output.OutputBoard();

                Console.Clear();

                logic.FallIntoPlaceAI();

                Console.WriteLine(Environment.NewLine);
                output.OutputBoard();

                Console.Clear();

                helper++;

                System.Threading.Thread.Sleep(2000);
            }

            Console.Clear();

            output.OutputWinMessage(helper);
            output.OutputBoard();

            System.Threading.Thread.Sleep(5000);

            Restart();
        }

        public void Multiplayer()
        { 
            int columnIdx;
            int helper = 0;

            while (!logic.GameOver())
            {
                inputCommand.InputColumn(helper);

                columnIdx = Convert.ToInt32(inputCommand.ReadColumnInput()) - 1;

                logic.FallIntoPlace(columnIdx, helper);

                Console.WriteLine(Environment.NewLine);
                output.OutputBoard();

                Console.Clear();

                helper++;

                System.Threading.Thread.Sleep(2000);
            }
            Console.Clear();

            output.OutputWinMessage(helper);
            output.OutputBoard();

            System.Threading.Thread.Sleep(5000);

            Restart();
        }
    }
}
