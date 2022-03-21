using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPXzadatak1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Intro intro = new Intro();
            Logic logic = new Logic();

            intro.PrintIntro();

            logic.FindColumn(2);
            logic.FindColumn(2);

            DisplayBoard();
        }

        static void DisplayBoard() //testing
        {
            int rowLength = Logic.Instance.BoardLayout.GetLength(0);
            int columnLength = Logic.Instance.BoardLayout.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    if (Logic.Instance.BoardLayout[i, j] != null)
                    {
                        Console.Write(string.Format("1 "));
                    }
                    else
                    {
                        Console.Write(string.Format("0 "));
                    }
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
