using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPXzadatak1
{
    public class Gameplay
    {
        public static readonly Player firstPlayer = new Player();
        public static readonly Player secondPlayer = new Player();
        public static readonly Input inputCommand = new Input();


        public void Start()
        {
            Intro intro = new Intro();
            Logic logic = new Logic();
            Input input = new Input();

            int columnIdx;
            int helper = 0;

            intro.PrintIntro();

            while (!logic.GameOver())
            {

                inputCommand.InputColumn(helper);

                columnIdx = Convert.ToInt32(inputCommand.ReadColumnInput()) - 1;

                logic.FallIntoPlace(columnIdx, helper);

                Console.WriteLine(Environment.NewLine);
                input.Output();
                helper++;

                System.Threading.Thread.Sleep(2000);
            }

            Console.Clear();
            input.Output();
        }
    }
}
