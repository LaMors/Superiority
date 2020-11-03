using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FindIndexOfCell
{

    public static int[,] IndexOf(GameObject[,] array, Cell value)
    {
        int[,] index = new int[,]
                    {
                        {-1 },
                        {-1 }
                    };

        for (int y = 0; y < array.GetLength(0); y++)
        {
            for (int x = 0; x < array.GetLength(1); x++)
            {
                var cell = array[y, x].GetComponent<Cell>();

                if (ReferenceEquals(cell, value))
                {
                    index = new int[,]
                    {
                        {y },
                        {x }
                    };
                    return index;
                }
            }
        }
        return index;
    }


}
