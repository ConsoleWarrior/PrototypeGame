using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIneGreen : Mine
{

    public override void OnClickMine()
    {
        Storage.cGreen += countIncrease;
        Debug.Log(countIncrease);
    }
    public override void OnClickMineIncreaseUpgrade()
    {
        if (Storage.cGreen >= costIncrease)
        {
            Storage.cGreen -= costIncrease;
            costIncrease *= 10;
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
            costAutoIncrease *= 10;
            costAutoIncreaseT.text = costAutoIncrease.ToString();
            countAutoIncrease++;
            countAutoIncreaseT.text = countAutoIncrease.ToString();
        }
    }
    public override void Craft()
    {
        Storage.cGreen += countAutoIncrease;
    }
}
