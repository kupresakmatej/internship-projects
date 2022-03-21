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

        private int counterPlayerHelper;

        int rowLength = Logic.Instance.BoardLayout.GetLength(0);
        int columnLength = Logic.Instance.BoardLayout.GetLength(1);

        public Logic()
        {
            
        }

        public void FallIntoPlace(int columnIdx) //greške sa indeksima
        {
            bool activePlayer = DetermineActivePlayer();
            int counterBoardHelper = 1;

            for (int i = columnLength - 1; i >= 0; i--)
            {
                if (activePlayer && Logic.Instance.BoardLayout[i - counterBoardHelper, columnIdx] != null)
                {
                    Logic.Instance.BoardLayout[i - counterBoardHelper, columnIdx] = new Coin(Gameplay.firstPlayer.Color);
                    break;
                }
                else if (!activePlayer && Logic.Instance.BoardLayout[i - counterBoardHelper, columnIdx] != null)
                {
                    Logic.Instance.BoardLayout[i - counterBoardHelper, columnIdx] = new Coin(Gameplay.secondPlayer.Color);
                    break;
                }
            }
            counterBoardHelper++;
        }

        public void FindColumn(int column)
        {
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    if (i == column)
                    {
                        FallIntoPlace(column);
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
                        counterPlayerHelper++;
                    }
                }
            }

            if(counterPlayerHelper % 2 == 0)
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
