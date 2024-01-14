using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineWhite : Mine
{

    public override void OnClickMine()
    {
        Storage.cWhite += countIncrease;
    }
    public override void OnClickMineIncreaseUpgrade()
    {
        if (Storage.cWhite >= costIncrease)
        {
            Storage.cWhite -= costIncrease;
            costIncrease *= 10;
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
            costAutoIncrease *= 10;
            costAutoIncreaseT.text = costAutoIncrease.ToString();
            countAutoIncrease++;
            countAutoIncreaseT.text = countAutoIncrease.ToString();
        }
    }
    public override void Craft()
    {
        Storage.cWhite += countAutoIncrease;
    }
}
