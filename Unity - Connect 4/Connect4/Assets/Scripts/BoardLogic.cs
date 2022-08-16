using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardLogic
{
    public Coin[,] BoardLayout { get; set; }

    public BoardLogic()
    {
        BoardLayout = new Coin[6, 7];
    }

    public void FillBoard()
    {
        for(int i = 0; i < 6; i++)
        {
            for(int j = 0; i < 7; j++)
            {
                BoardLayout[i, j] = Coin.Empty;
            }
        }
    }

    public void PrintBoard()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                Debug.Log(BoardLayout[i, j]);
            }
        }
    }

    public void ClearBoard()
    {
        BoardLayout = new Coin[6, 7];
    }
}
