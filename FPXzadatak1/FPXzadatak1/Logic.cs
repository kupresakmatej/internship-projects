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

        public Logic()
        {
            
        }

        public void FallIntoPlace()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 7; j > 0; j--)
                {
                    if (Logic.Instance.BoardLayout[i, j] != null)
                    {
                        //if(DetermineActivePlayer)
                        //{

                        //}
                    }
                }
            }
        }

        public void FindColumn(int column)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (j == column)
                    {

                    }
                }
            }
        }

        public bool DetermineActivePlayer()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
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
