﻿using System;
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

        public static Coin coin = new Coin();

        public Logic(Board Board)
        {
            board = Board;
        }

        int ROWS_COUNT = 6;
        int COLUMNS_COUNT = 7;

        public bool GameOver()
        {
            if(coin != Coin.Empty)
            {
                return true;
            }

            return false;
        }

        public Coin FallIntoPlace(int columnIdx, int helper) //popravljeno
        {
            //bool activePlayer = DetermineActivePlayer();

            for (int i = 0; i < 6; i++)
            {
                if ((helper % 2 == 0) && ((i == 6 - 1) || board.BoardLayout[i + 1, columnIdx] != Coin.Empty)) //provjerava je li došao do kraja, ili je naišao na već popunjeno mjesto
                {
                    board.BoardLayout[i, columnIdx] = Coin.PlayerA;

                    if(CheckRows() != Coin.Empty)
                    {
                        coin = CheckRows();
                    }
                    else if (CheckColumns(columnIdx) != Coin.Empty)
                    {
                        coin = CheckColumns(columnIdx);
                    }
                    else if (CheckDiagonallyUp(i, columnIdx) != Coin.Empty)
                    {
                        coin = CheckDiagonallyUp(i, columnIdx);
                    }
                    else if (CheckDiagonallyDown(i, columnIdx) != Coin.Empty)
                    {
                        coin = CheckDiagonallyDown(i, columnIdx);
                    }

                    break;
                }
                else if ((helper % 2 != 0) && ((i == 6 - 1) || board.BoardLayout[i + 1, columnIdx] != Coin.Empty))
                {
                    board.BoardLayout[i, columnIdx] = Coin.PlayerB;

                    if (CheckRows() != Coin.Empty)
                    {
                        coin = CheckRows();
                    }
                    else if (CheckColumns(columnIdx) != Coin.Empty)
                    {
                        coin = CheckColumns(columnIdx);
                    }
                    else if (CheckDiagonallyUp(i, columnIdx) != Coin.Empty)
                    {
                        coin = CheckDiagonallyUp(i, columnIdx);
                    }
                    else if (CheckDiagonallyDown(i, columnIdx) != Coin.Empty)
                    {
                        coin = CheckDiagonallyDown(i, columnIdx);
                    }

                    break;
                }
            }

            return coin;
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

        private Coin CheckForWinner(Coin[] coins)
        {
            int countA = 0;
            int countB = 0;

            for (int i = 0; i < coins.Length; i++)
            {
                if (coins[i] == Coin.Empty)
                {
                    countA = 0;
                    countB = 0;
                }
                else if (coins[i] == Coin.PlayerA)
                {
                    countA++;
                    countB = 0;
                }
                else
                {
                    countB++;
                    countA = 0;
                }


                if (countA >= 4)
                    return Coin.PlayerA;
                else if (countB >= 4)
                    return Coin.PlayerB;
            }

            return Coin.Empty;
        }

        public Coin CheckRows()
        {
            Coin[] coins = new Coin[COLUMNS_COUNT];

            for (int i = 0; i < ROWS_COUNT; i++)
            {
                for (int j = 0; j < COLUMNS_COUNT; j++)
                    coins[j] = board.BoardLayout[i, j];

                var result = CheckForWinner(coins);
                if (result != Coin.Empty)
                    return result;
            }

            return Coin.Empty;
        }

        public Coin CheckColumns(int column)
        {
            Coin[] coins = new Coin[ROWS_COUNT];

            for(int i = 0; i < 6; i++)
            {
                coins[i] = board.BoardLayout[i, column];

                var result = CheckForWinner(coins);
                if (result != Coin.Empty)
                    return result;
            }

            return Coin.Empty;
        }

        public Coin CheckDiagonallyUp(int row, int column)
        {
            Coin[] coins = new Coin[] { Coin.Empty };

            for(int k = 0; k < coins.Length; k++)
            {
                for (int i = 6 - row; i < board.BoardLayout.GetLength(0); i++)
                {
                    for (int j = 7 - column; j < board.BoardLayout.GetLength(1); j++)
                    {
                        coins[k] = board.BoardLayout[i, j];

                        var result = CheckForWinner(coins);
                        if (result != Coin.Empty)
                            return result;
                    }
                }
            }

            return Coin.Empty;
        }

        public Coin CheckDiagonallyDown(int row, int column)
        {
            Coin[] coins = new Coin[] { Coin.Empty };

            for(int k = 0; k < coins.Length; k++)
            {
                for (int i = 6 - row; i > board.BoardLayout.GetLength(0) - row; i--)
                {
                    for (int j = 7 - column; j > board.BoardLayout.GetLength(1) - column; j--)
                    {
                        coins[k] = board.BoardLayout[i, j];

                        var result = CheckForWinner(coins);
                        if (result != Coin.Empty)
                            return result;
                    }
                }
            }

            return Coin.Empty;
        }
    }
}