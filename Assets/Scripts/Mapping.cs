using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mapping : MonoBehaviour
{
    int[,] ints1 = new int[5, 5];
    void Start()
    {
        Debug.Log(Connection(ints1,0,0));
    }
    public int Connection(int[,] ints, int x, int y)
    {
        int count = 0;
        for (int i = -2; i < 3; i++)
        {
            for (int j = -2; j < 3; j++)
            {
                try
                {
                    if (ints[x + i, y + j] == 0) count++;
                    Debug.Log(i+"*"+j);

                }
                catch (IndexOutOfRangeException)
                {
                    Debug.Log("error");
                }
            }
        }

        return count;
    }
}
