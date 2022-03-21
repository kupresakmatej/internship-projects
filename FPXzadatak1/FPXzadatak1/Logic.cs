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
                        //Logic.Instance.BoardLayout[i, j] += 
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
    }
}
