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
        private static Output output;

        public Logic(Board Board)
        {
            board = Board;
        }


        //int rowLength = board.BoardLayout.GetLength(0);
        //int columnLength = board.BoardLayout.GetLength(1);

        //public bool GameOver()
        //{
        //    for(int i = 0; i < 6; i++)
        //    {
        //        for(int j = 0; j < 7; j++)
        //        {
        //            if(WinHorizontally(i, j))
        //            {
        //                return true;
        //            }

        //            if(WinVertically(i, j))
        //            {
        //                return true;
        //            }

        //            if(WinDiagonallyUp(i, j))
        //            {
        //                return true;
        //            }

        //            if(WinDiagonallyDown(i, j))
        //            {
        //                return true;
        //            }
        //        }
        //    }

        //    return false;
        //}

        public Coin FallIntoPlace(int columnIdx, int helper) //popravljeno
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

            return Coin.Empty;
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
        //public bool WinHorizontally(int row, int column)
        //{
        //    if(column + 3 >= 7) //prekida odmah, ako nema uopće 4 mjesta da provjeri
        //    {
        //        return false;
        //    }

        //    for(int i = 0; i < 4; i++)
        //    {
        //        if (board.BoardLayout[row, column + i] == Coin.Empty || board.BoardLayout[row, column + i] != board.BoardLayout[row, column])
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //public bool WinVertically(int row, int column)
        //{
        //    if(row + 3 >= 6) //prekida odmah, ako nema uopće 4 mjesta da provjeri
        //    {
        //        return false;
        //    }

        //    for(int i = 0; i < 4; i++)
        //    {
        //        if(board.BoardLayout[row + i, column] == Coin.Empty || board.BoardLayout[row + i, column] != board.BoardLayout[row, column])
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //public bool WinDiagonallyUp(int row, int column)
        //{
        //    if(row - 3 < 0) //prekida odmah, ako nema uopće 4 mjesta da provjeri
        //    {
        //        return false;
        //    }
        //    if(column + 3 >= 7)
        //    {
        //        return false;
        //    }

        //    for(int i = 0; i < 4; i++)
        //    {
        //        if(board.BoardLayout[row - i, column + i] == Coin.Empty || board.BoardLayout[row - i, column + i] != board.BoardLayout[row, column])
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //public bool WinDiagonallyDown(int row, int column)
        //{
        //    if(row + 3 >= 6) //prekida odmah, ako nema uopće 4 mjesta da provjeri
        //    {
        //        return false;
        //    }
        //    if(column + 3 >= 7)
        //    {
        //        return false;
        //    }

        //    for(int i = 0; i < 4; i++)
        //    {
        //        if(board.BoardLayout[row + i, column + i] == Coin.Empty || board.BoardLayout[row + i, column + i] != board.BoardLayout[row, column])
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        public Coin Winner(Coin[] coins)
        {
            int index = 0;

            for (int i = 0; i < coins.Length - 1; i++)
            {
                if (coins[i] != coins[i + 1])
                {
                    return Coin.Empty;
                }
                else
                {
                    index = i;
                }
            }

            return coins[index];
        }

        public Coin[] CheckHorizontally(int row)
        {
            Coin[] coins = new Coin[7];
            
            for(int i = 0; i < 7; i++)
            {
                coins[i] = board.BoardLayout[row, i];
            }

            return coins;
        }

        public Coin[] CheckVertically(int column)
        {
            Coin[] coins = new Coin[6];

            for(int i = 0; i < 6; i++)
            {
                coins[i] = board.BoardLayout[i, column];
            }

            return coins;
        }

        public Coin[] CheckDiagonallyUp(int row, int column)
        {
            Coin[] coins = new Coin[] { Coin.Empty };

            for(int k = 0; k < coins.Length; k++)
            {
                for (int i = 6 - row; i < board.BoardLayout.GetLength(0); i++)
                {
                    for (int j = 7 - column; j < board.BoardLayout.GetLength(1); j++)
                    {
                        coins[k] = board.BoardLayout[i, j];
                    }
                }
            }

            return coins;
        }

        public Coin[] CheckDiagonallyDown(int row, int column)
        {
            Coin[] coins = new Coin[] { Coin.Empty };

            for(int k = 0; k < coins.Length; k++)
            {
                for (int i = 6 - row; i > board.BoardLayout.GetLength(0) - row; i--)
                {
                    for (int j = 7 - column; j > board.BoardLayout.GetLength(1) - column; j--)
                    {
                        coins[k] = board.BoardLayout[i, j];
                    }
                }
            }

            return coins;
        }
    }
}