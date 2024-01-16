using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineWhite : Mine
{

    public override void OnClickMine()
    {
        if (Storage.cGrey >= countIncrease * 2)
        {
            Storage.cGrey -= countIncrease * 2;
            Storage.cWhite += countIncrease;
        }
    }
    public override void OnClickMineIncreaseUpgrade()
    {
        if (Storage.cWhite >= costIncrease)
        {
            Storage.cWhite -= costIncrease;
            costIncrease *= 3;
            costIncreaseT.text = costIncrease.ToString();
            countIncrease++;
            countIncreaseT.text = countIncrease.ToString();
        }
    }
    public override void OnClickMineAutoIncreaseUpgrade()
    {
        if (Storage.cWhite >= costAutoIncrease)
        {
            Storage.cWhite -= costAutoIncrease;
            costAutoIncrease *= 3;
            costAutoIncreaseT.text = costAutoIncrease.ToString();
            countAutoIncrease++;
            countAutoIncreaseT.text = countAutoIncrease.ToString();
        }
    }
    public override void Craft()
    {
        if (Storage.cGrey >= 2 * countAutoIncrease)
        {
            Storage.cGrey -= 2 * countAutoIncrease;
            Storage.cWhite += countAutoIncrease;
        }
    }
}
