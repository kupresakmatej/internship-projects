using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPXzadatak1
{
    public class Logic
    {
        public static readonly Board Instance = new Board();

        private int counter;

        int rowLength = Logic.Instance.BoardLayout.GetLength(0);
        int columnLength = Logic.Instance.BoardLayout.GetLength(1);

        public Logic()
        {
            
        }

        public void FallIntoPlace()
        {
            bool activePlayer = DetermineActivePlayer();

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    if (Logic.Instance.BoardLayout[i, j] != null)
                    {
                        if(activePlayer)
                        {
                            Logic.Instance.BoardLayout[i, j] = new Coin(Gameplay.firstPlayer.Color);
                        }
                        else
                        {
                            Logic.Instance.BoardLayout[i, j] = new Coin(Gameplay.secondPlayer.Color);
                        }
                    }
                }
            }
        }

        public void FindColumn(int column)
        {
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    if (j == column)
                    {
                        FallIntoPlace();
                    }
                }
            }
        }

        public bool DetermineActivePlayer()
        {
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    if (Logic.Instance.BoardLayout[i, j] != null)
                    {
                        counter++;
                    }
                }
            }

            if(counter % 2 == 0)
            {
                return true; //first player is active
            }
            else
            {
                return false; //second player is active
            }
        }
    }
}
