using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mapping : MonoBehaviour
{
    public Hex[] row0;
    public Hex[] row1;
    public Hex[] row2;
    public Hex[] row3;
    public Hex[] row4;
    public Hex[] row5;
    public static Hex[,] map2x = new Hex[6,8];
    //int[,] ints1 = new int[6, 8];
    void Start()
    {

        CreateMap2x(row0, 0);
        CreateMap2x(row1, 1);
        CreateMap2x(row2, 2);
        CreateMap2x(row3, 3);
        CreateMap2x(row4, 4);
        CreateMap2x(row5, 5);
    }
    public void TestBut()
    {
        Debug.Log(Connection(map2x, 3, 3));
    }
    public int Connection(Hex[,] hexes, int x, int y)
    {
        int count = 0;
        for (int i = -2; i < 3; i++)
        {
            for (int j = -2; j < 3; j++)
            {
                try
                {
                    switch (y % 2)
                    {
                        case 0:
                            if ((i == 2 & j != 0) || (i == -2 & (j == 2 || j == -2)) || (i == 0 & j == 0)) break;//Debug.Log(i + " exeption " + j);

                            else if (!hexes[x + i, y + j].owner)
                            {
                                count++;
                                //Debug.Log(i + "*" + j);
                            }
                            break;
                        case 1:
                            if ((i == -2 & j != 0) || (i == 2 & (j == 2 || j == -2)) || (i == 0 & j == 0)) break;//Debug.Log(i + " exeption " + j);
                            else if (!hexes[x + i, y + j].owner)
                            {
                                count++;
                                //Debug.Log(i + "*" + j);
                            }
                            break;
                    }
                    
                }
                catch (IndexOutOfRangeException)
                {
                    Debug.Log("exeption");
                }
            }
        }

        return count;
    }
    public void CreateMap2x(Hex[] row, int num)
    {
        for (int i = 0; i < 8; i++)
        {
            map2x[num,i] = row[i];
        }
    }
}
