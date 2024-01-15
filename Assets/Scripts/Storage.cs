using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Storage : MonoBehaviour
{
    public static int cGrey = 0;
    public static int cWhite = 0;
    public static int cGreen = 0;
    public static int cBlue = 0;
    public static int cViol = 0;
    public static int cYellow = 0;
    public static int cOrange = 0;
    public static int cRed = 0;
    public static int cBlack = 0;
    public static int cMoney = 0;

    public Text cGreyT;
    public Text cWhiteT;
    public Text cGreenT;
    public Text cBlueT;
    public Text cViolT;
    public Text cYellowT;
    public Text cOrangeT;
    public Text cRedT;
    public Text cBlackT;
    public Text cMoneyT;

    private void Update()
    {
        cGreyT.text = cGrey.ToString();
        cWhiteT.text = cWhite.ToString();
        cGreenT.text = cGreen.ToString();
        cBlueT.text = cBlue.ToString();
        cViolT.text = cViol.ToString();
        cYellowT.text = cYellow.ToString();
        cOrangeT.text = cOrange.ToString();
        cRedT.text = cRed.ToString();
        cBlackT.text = cBlack.ToString();

    }
}
