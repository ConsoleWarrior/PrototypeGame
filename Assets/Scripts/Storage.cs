using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Storage : MonoBehaviour
{

    public static int cMoney = 0;
    public static int[] storage = new int[9];
    public Text[] storageT = new Text[9];

    private void Update()
    {
        for (int i = 0; i < 9; i++)
        {
            storageT[i].text = storage[i].ToString();
        }
    }
}
