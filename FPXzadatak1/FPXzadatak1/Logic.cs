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

        //private int counterPlayerHelper = 1;

        int rowLength = Logic.Instance.BoardLayout.GetLength(0);
        int columnLength = Logic.Instance.BoardLayout.GetLength(1);

        public Logic()
        {
            
        }

        public bool GameOver()
        {
            for(int i = 0; i < rowLength; i++)
            {
                for(int j = 0; j < columnLength; j++)
                {
                    if(WinHorizontally(i, j))
                    {
                        return true;
                    }

                    if(WinVertically(i, j))
                    {
                        return true;
                    }

                    if(WinDiagonallyUp(i, j))
                    {
                        return true;
                    }

                    if(WinDiagonallyDown(i, j))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void FallIntoPlace(int columnIdx, int helper) //popravljeno
        {
            //bool activePlayer = DetermineActivePlayer();

            for (int i = 0; i < rowLength; i++)
            {
                if ((helper % 2 == 0) && ((i == rowLength - 1) || Logic.Instance.BoardLayout[i + 1, columnIdx] != Coin.Empty)) //provjerava je li došao do kraja, ili je naišao na već popunjeno mjesto
                {
                    Logic.Instance.BoardLayout[i, columnIdx] = Coin.PlayerA;
                    break;
                }
                else if ((helper % 2 != 0) && ((i == rowLength - 1) || Logic.Instance.BoardLayout[i + 1, columnIdx] != Coin.Empty))
                {
                    Logic.Instance.BoardLayout[i, columnIdx] = Coin.PlayerB;
                    break;
                }
            }
        }

        //Nepotrebno

        //public void FindColumn(int column)
        //{
        //    for (int i = 0; i < rowLength; i++)
        //    {
        //        for (int j = 0; j < columnLength; j++)
        //        {
        //            if (i == column)
        //            {
        //                FallIntoPlace(column);
        //            }
        //        }
        //    }
        //}

        //public bool DetermineActivePlayer()
        //{
        //    for (int i = 0; i < rowLength; i++)
        //    {
        //        for (int j = 0; j < columnLength; j++)
        //        {
        //            if (Logic.Instance.BoardLayout[i, j] != null)
        //            {
        //                counterPlayerHelper++;
        //            }
        //        }
        //    }

        //    if(counterPlayerHelper % 2 == 0)
        //    {
        //        return false; //first player is active
        //    }
        //    else
        //    {
        //        return true; //second player is active
        //    }
        //}


        //zamijenio true i false na svima, odnosno okrenio uvjete
        public bool WinHorizontally(int row, int column)
        {
            if(column + 3 >= columnLength) //prekida odmah, ako nema uopće 4 mjesta da provjeri
            {
                return false;
            }

            for(int i = 0; i < 4; i++)
            {
                if (Logic.Instance.BoardLayout[row, column + i] == Coin.Empty || Logic.Instance.BoardLayout[row, column + i] != Logic.Instance.BoardLayout[row, column])
                {
                    return false;
                }
            }
            return true;
        }

        public bool WinVertically(int row, int column)
        {
            if(row + 3 >= rowLength) //prekida odmah, ako nema uopće 4 mjesta da provjeri
            {
                return false;
            }

            for(int i = 0; i < 4; i++)
            {
                if(Logic.Instance.BoardLayout[row + i, column] == Coin.Empty || Logic.Instance.BoardLayout[row + i, column] != Logic.Instance.BoardLayout[row, column])
                {
                    return false;
                }
            }
            return true;
        }

        public bool WinDiagonallyUp(int row, int column)
        {
            if(row - 3 < 0) //prekida odmah, ako nema uopće 4 mjesta da provjeri
            {
                return false;
            }
            if(column + 3 >= columnLength)
            {
                return false;
            }

            for(int i = 0; i < 4; i++)
            {
                if(Logic.Instance.BoardLayout[row - i, column + i] == Coin.Empty || Logic.Instance.BoardLayout[row - i, column + i] != Logic.Instance.BoardLayout[row, column])
                {
                    return false;
                }
            }
            return true;
        }

        public bool WinDiagonallyDown(int row, int column)
        {
            if(row + 3 >= rowLength) //prekida odmah, ako nema uopće 4 mjesta da provjeri
            {
                return false;
            }
            if(column + 3 >= columnLength)
            {
                return false;
            }

            for(int i = 0; i < 4; i++)
            {
                if(Logic.Instance.BoardLayout[row + i, column + i] == Coin.Empty || Logic.Instance.BoardLayout[row + i, column + i] != Logic.Instance.BoardLayout[row, column])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
