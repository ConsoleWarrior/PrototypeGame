using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIneGreen : Mine
{

    public override void OnClickMine()
    {
        if (Storage.cWhite >= countIncrease * 2)
        {
            Storage.cWhite -= countIncrease * 2;
            Storage.cGreen += countIncrease;
        }
    }
    public override void OnClickMineIncreaseUpgrade()
    {
        if (Storage.cGreen >= costIncrease)
        {
            Storage.cGreen -= costIncrease;
            costIncrease *= 3;
            costIncreaseT.text = costIncrease.ToString();
            countIncrease++;
            countIncreaseT.text = countIncrease.ToString();
        }
    }
    public override void OnClickMineAutoIncreaseUpgrade()
    {
        if (Storage.cGreen >= costAutoIncrease)
        {
            Storage.cGreen -= costAutoIncrease;
            costAutoIncrease *= 3;
            costAutoIncreaseT.text = costAutoIncrease.ToString();
            countAutoIncrease++;
            countAutoIncreaseT.text = countAutoIncrease.ToString();
        }
    }
    public override void Craft()
    {
        if (Storage.cWhite >= 2 * countAutoIncrease)
        {
            Storage.cWhite -= 2 * countAutoIncrease;
            Storage.cGreen += countAutoIncrease;
        }
    }
}
