using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Storage : MonoBehaviour
{

    public static int cMoney = 0;
    public Text cMoneyT;
    public static int[] storage = new int[9];
    public Text[] storageT = new Text[9];
    public static bool[] hexs = new bool[9];

    void Start()
    {
        hexs[0] = true;
    }
    void Update()
    {
        for (int i = 0; i < 9; i++)
        {
            storageT[i].text = storage[i].ToString();
        }
        cMoneyT.text = cMoney.ToString();
    }
}
