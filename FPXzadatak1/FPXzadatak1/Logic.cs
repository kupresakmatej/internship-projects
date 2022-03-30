using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPXzadatak1
{
    public class Logic
    {
        //private static Board board = new Board();

        //private int counterPlayerHelper = 1;

        private static Board board;

        public Logic(Board Board)
        {
            board = Board;
        }


        //int rowLength = board.BoardLayout.GetLength(0);
        //int columnLength = board.BoardLayout.GetLength(1);

        public bool GameOver()
        {
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 7; j++)
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

            for (int i = 0; i < 6; i++)
            {
                if ((helper % 2 == 0) && ((i == 6 - 1) || board.BoardLayout[i + 1, columnIdx] != Coin.Empty)) //provjerava je li došao do kraja, ili je naišao na već popunjeno mjesto
                {
                    board.BoardLayout[i, columnIdx] = Coin.PlayerA;
                    break;
                }
                else if ((helper % 2 != 0) && ((i == 6 - 1) || board.BoardLayout[i + 1, columnIdx] != Coin.Empty))
                {
                    board.BoardLayout[i, columnIdx] = Coin.PlayerB;
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
            if(column + 3 >= 7) //prekida odmah, ako nema uopće 4 mjesta da provjeri
            {
                return false;
            }

            for(int i = 0; i < 4; i++)
            {
                if (board.BoardLayout[row, column + i] == Coin.Empty || board.BoardLayout[row, column + i] != board.BoardLayout[row, column])
                {
                    return false;
                }
            }
            return true;
        }

        public bool WinVertically(int row, int column)
        {
            if(row + 3 >= 6) //prekida odmah, ako nema uopće 4 mjesta da provjeri
            {
                return false;
            }

            for(int i = 0; i < 4; i++)
            {
                if(board.BoardLayout[row + i, column] == Coin.Empty || board.BoardLayout[row + i, column] != board.BoardLayout[row, column])
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
            if(column + 3 >= 7)
            {
                return false;
            }

            for(int i = 0; i < 4; i++)
            {
                if(board.BoardLayout[row - i, column + i] == Coin.Empty || board.BoardLayout[row - i, column + i] != board.BoardLayout[row, column])
                {
                    return false;
                }
            }
            return true;
        }

        public bool WinDiagonallyDown(int row, int column)
        {
            if(row + 3 >= 6) //prekida odmah, ako nema uopće 4 mjesta da provjeri
            {
                return false;
            }
            if(column + 3 >= 7)
            {
                return false;
            }

            for(int i = 0; i < 4; i++)
            {
                if(board.BoardLayout[row + i, column + i] == Coin.Empty || board.BoardLayout[row + i, column + i] != board.BoardLayout[row, column])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
