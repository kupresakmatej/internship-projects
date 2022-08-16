using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic
{
    int ROWS_COUNT = 6;
    int COLUMNS_COUNT = 7;

    private static BoardLogic board;
    public static Coin coin = new Coin();

    public Logic(BoardLogic Board)
    {
        board = Board;
    }

    public static bool GameOver()
    {
        if(coin != Coin.Empty)
        {
            return true;
        }

        return false;
    }

    public Coin DropIntoBoard(int columnIdx, int helper)
    {
        for (int i = 0; i < ROWS_COUNT; i++)
        {
            if ((helper % 2 == 0) && ((i == 6 - 1) || board.BoardLayout[i + 1, columnIdx] != Coin.Empty))
            {
                board.BoardLayout[i, columnIdx] = Coin.PlayerA;

                if (CheckRows() != Coin.Empty)
                {
                    coin = CheckRows();
                }
                else if (CheckColumns(columnIdx) != Coin.Empty)
                {
                    coin = CheckColumns(columnIdx);
                }
                else if (CheckDiagonallyUp() != Coin.Empty)
                {
                    coin = CheckDiagonallyUp();
                }
                else if (CheckDiagonallyDown() != Coin.Empty)
                {
                    coin = CheckDiagonallyDown();
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
                else if (CheckDiagonallyUp() != Coin.Empty)
                {
                    coin = CheckDiagonallyUp();
                }
                else if (CheckDiagonallyDown() != Coin.Empty)
                {
                    coin = CheckDiagonallyDown();
                }

                break;

            }
        }

        return coin;
    }


    public Coin CheckForWinner(Coin[] coins)
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
            {
                return Coin.PlayerA;
            }  
            else if (countB >= 4)
            {
                return Coin.PlayerB;
            }
        }

        return Coin.Empty;
    }


    public Coin CheckRows()
    {
        Coin[] coins = new Coin[COLUMNS_COUNT];

        for(int i = 0; i < ROWS_COUNT; i++)
        {
            for(int j = 0; j < COLUMNS_COUNT; j++)
            {
                coins[j] = board.BoardLayout[i, j];
            }

            var result = CheckForWinner(coins);
            if (result != Coin.Empty)
                return result;
        }

        return Coin.Empty;
    }

    public Coin CheckColumns(int column)
    {
        Coin[] coins = new Coin[ROWS_COUNT];

        for (int i = 0; i < ROWS_COUNT; i++)
        {
            coins[i] = board.BoardLayout[i, column];

            var result = CheckForWinner(coins);
            if (result != Coin.Empty)
                return result;
        }

        return Coin.Empty;
    }

    public Coin CheckDiagonallyUp()
    {
        for (int i = 0; i < ROWS_COUNT; i++)
        {
            Coin[] coins = new Coin[i];

            for (int j = 0; j < i; j++)
            {
                coins[j] = board.BoardLayout[j, COLUMNS_COUNT - i + j];
            }

            var result = CheckForWinner(coins);
            if (result != Coin.Empty)
                return result;
        }

        for (int i = 0; i < ROWS_COUNT; i++)
        {
            Coin[] coins = new Coin[i];

            for (int j = 0; j < i; j++)
            {
                coins[j] = board.BoardLayout[ROWS_COUNT - i + j, j];
            }

            var result = CheckForWinner(coins);
            if (result != Coin.Empty)
                return result;
        }

        for (int i = 1; i <= (ROWS_COUNT + COLUMNS_COUNT - 1); i++)
        {
            Coin[] coins = new Coin[i];

            int start_column = Math.Max(0, i - ROWS_COUNT);

            int counter = Math.Min(i, Math.Min((COLUMNS_COUNT - start_column), ROWS_COUNT));

            for (int j = 0; j < counter; j++)
            {
                coins[j] = board.BoardLayout[Math.Min(ROWS_COUNT, i) - j - 1, start_column + j];
            }

            var result = CheckForWinner(coins);
            if (result != Coin.Empty)
                return result;
        }

        return Coin.Empty;
    }

    public Coin CheckDiagonallyDown()
    {
        for (int i = 0; i < ROWS_COUNT; i++)
        {
            Coin[] coins = new Coin[i];

            for (int j = 0; j < i; j++)
            {
                coins[j] = board.BoardLayout[ROWS_COUNT - i + j, COLUMNS_COUNT - j - 1];
            }

            var result = CheckForWinner(coins);
            if (result != Coin.Empty)
                return result;
        }

        for (int i = 0; i < ROWS_COUNT; i++)
        {
            Coin[] coins = new Coin[i];

            for (int j = 0; j < i; j++)
            {
                coins[j] = board.BoardLayout[ROWS_COUNT - j - 1, i - j - 1];
            }

            var result = CheckForWinner(coins);
            if (result != Coin.Empty)
                return result;
        }

        Coin[,] coinsFlipped = Flip();

        for (int i = (ROWS_COUNT + COLUMNS_COUNT - 1); i >= 1; i--)
        {
            Coin[] coins = new Coin[i];

            int start_column = Math.Max(0, i - ROWS_COUNT);

            int counter = Math.Min(i, Math.Min((COLUMNS_COUNT - start_column), ROWS_COUNT));

            for (int j = 0; j < counter; j++)
            {
                coins[j] = coinsFlipped[Math.Min(ROWS_COUNT, i) - j - 1, start_column + j];
            }

            var result = CheckForWinner(coins);
            if (result != Coin.Empty)
                return result;
        }

        return Coin.Empty;
    }

    public Coin[,] Flip()
    {
        Coin[,] coins = new Coin[6, 7];

        for (int i = 0; i < ROWS_COUNT; i++)
        {
            for (int j = 0; j < COLUMNS_COUNT; j++)
            {
                coins[ROWS_COUNT - 1 - i, j] = board.BoardLayout[i, j];
            }
        }

        return coins;
    }
}