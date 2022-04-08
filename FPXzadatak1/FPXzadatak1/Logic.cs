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

        public static Coin coin = new Coin();

        public Logic(Board Board)
        {
            board = Board;
        }

        int ROWS_COUNT = 6;
        int COLUMNS_COUNT = 7;
        public static int LASTPOS_X = 0;
        public static int LASTPOS_Y = 0;

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

        public Coin FallIntoPlaceSP(int columnIdx) //popravljeno
        {
            //bool activePlayer = DetermineActivePlayer();

            for (int i = 0; i < ROWS_COUNT; i++)
            {
                if (((i == 6 - 1) || board.BoardLayout[i + 1, columnIdx] != Coin.Empty)) //provjerava je li došao do kraja, ili je naišao na već popunjeno mjesto
                {
                    board.BoardLayout[i, columnIdx] = Coin.PlayerA;
                    LASTPOS_X = i;
                    LASTPOS_Y = columnIdx;

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
                //else if ((helper % 2 != 0) && ((i == 6 - 1) || board.BoardLayout[i + 1, aiColumn] != Coin.Empty))
                //{
                //    board.BoardLayout[i, aiColumn] = Coin.PlayerB;

                //    if (CheckRows() != Coin.Empty)
                //    {
                //        coin = CheckRows();
                //    }
                //    else if (CheckColumns(columnIdx) != Coin.Empty)
                //    {
                //        coin = CheckColumns(columnIdx);
                //    }
                //    else if (CheckDiagonallyUp() != Coin.Empty)
                //    {
                //        coin = CheckDiagonallyUp();
                //    }
                //    else if (CheckDiagonallyDown() != Coin.Empty)
                //    {
                //        coin = CheckDiagonallyDown();
                //    }

                //    break;
                //}
            }

            return coin;
        }

        public Coin FallIntoPlaceAI()
        {
            int columnIdx = DetermineColumnAI();

            for (int i = 0; i < ROWS_COUNT; i++)
            {
                if ((i == 6 - 1) || board.BoardLayout[i + 1, columnIdx] != Coin.Empty)
                {
                    board.BoardLayout[i, columnIdx] = Coin.PlayerB;
                    LASTPOS_X = i;
                    LASTPOS_Y = columnIdx;

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

        public int DetermineColumnAI()
        {
            int column;
            Random random = new Random();

            if (CheckHorizontallyAI() == Coin.PlayerB || CheckHorizontallyAI() == Coin.PlayerB)
            {
                column = LASTPOS_Y + 1;
            }
            else if (CheckVerticallyAI() == Coin.PlayerB || CheckVerticallyAI() == Coin.PlayerA)
            {
                column = LASTPOS_Y;
            }
            else if (CheckDiagonallyDownAI() == Coin.PlayerB || CheckDiagonallyDownAI() == Coin.PlayerA)
            {
                column = LASTPOS_Y - 1;
            }
            else if (CheckDiagonallyUpAI() == Coin.PlayerB ||CheckDiagonallyUpAI() == Coin.PlayerA)
            {
                column = LASTPOS_Y + 1;
            }
            else
            {
                column = random.Next(1, 7);
            }

            return column;
        }

        public Coin CheckHorizontallyAI()
        {
            Coin coin = new Coin();

            int counter = 0;
            int k = 0, m = 0;
            
            for(int i = 0; i < ROWS_COUNT; i++)
            {
                for(int j = 0; j < COLUMNS_COUNT; j++)
                {
                    if(board.BoardLayout[i, j] == Coin.PlayerA)
                    {
                        counter++;
                        k = i;
                        m = j;
                    }
                    else if(board.BoardLayout[i, j] == Coin.PlayerB)
                    {
                        counter++;
                        k = i;
                        m = j;
                    }
                }

                if (counter == 3)
                {
                    LASTPOS_X = k;
                    LASTPOS_Y = m;
                    coin = board.BoardLayout[k, m];
                    return coin;
                }
            }
            return Coin.Empty;

            //return true;
        }

        public Coin CheckVerticallyAI()
        {
            Coin coin = new Coin();

            int counter = 0;
            int k = 0;
            int m = 0;


            //if (LASTPOS_X + 3 >= ROWS_COUNT)
            //{
            //    return Coin.Empty;
            //}

            for (int i = 0; i < ROWS_COUNT; i++)
            {
                if (board.BoardLayout[i, LASTPOS_Y] == Coin.PlayerA)
                {
                    counter++;
                    k = i;
                    m = LASTPOS_Y;
                    //return false;
                }
                else if(board.BoardLayout[i, LASTPOS_Y] == Coin.PlayerB)
                {
                    counter++;
                    k = i;
                    m = LASTPOS_Y;
                    //return false;
                }
            }

            if (counter == 3)
            {
                coin = board.BoardLayout[k, m];
                return coin;
            }
            return Coin.Empty;

            //return true;
        }

        private Coin CheckDiagonallyDownAI()
        {
            Coin coin = new Coin();

            int counter = 0;
            int k = 0;
            int m = 0;

            if (LASTPOS_X + 3 >= ROWS_COUNT)
            {
                return Coin.Empty;
            }
            if (LASTPOS_Y + 3 >= COLUMNS_COUNT)
            {
                return Coin.Empty;
            }

            for (int i = 0; i < 3; i++)
            {
                if (board.BoardLayout[LASTPOS_X + i, LASTPOS_Y + i] == Coin.PlayerA) 
                {
                    counter++;
                    k = LASTPOS_X + i;
                    m = LASTPOS_Y + i;
                    //return false; 
                }
            }

            if (counter == 3)
            {
                coin = board.BoardLayout[k, m];
                return coin;
            }
            return Coin.Empty;

            //return true;
        }

        private Coin CheckDiagonallyUpAI()
        {
            Coin coin = new Coin();

            int counter = 0;
            int k = 0;
            int m = 0;

            if(LASTPOS_X + 3 < 0)
            {
                return Coin.Empty;
            }
            if(LASTPOS_Y + 3 >= COLUMNS_COUNT)
            {
                return Coin.Empty;
            }

            for (int i = 0; i < 3; i++)
            {
                if (board.BoardLayout[LASTPOS_X - i, LASTPOS_Y + i] == Coin.PlayerA)
                {
                    counter++;
                    k = LASTPOS_X - i;
                    m = LASTPOS_Y + i;
                    //return false;
                }
            }

            if (counter == 3)
            {
                coin = board.BoardLayout[k, m];
                return coin;
            }
            return Coin.Empty;

            //return true;
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

            for(int i = 0; i < ROWS_COUNT; i++)
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

            for(int i = 0; i < ROWS_COUNT; i++)
            {
                for(int j = 0; j < COLUMNS_COUNT; j++)
                {
                    coins[ROWS_COUNT - 1 - i, j] = board.BoardLayout[i, j];
                }
            }

            return coins;
        }
    }
}