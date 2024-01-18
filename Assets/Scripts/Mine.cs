using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mine : MonoBehaviour, IPointerClickHandler
{
    public int mineIndex;
    public GameObject UpgradePanel;

    public Text countIncreaseT;
    public Text countAutoIncreaseT;
    public Text costIncreaseT;
    public Text costAutoIncreaseT;
    public int countIncrease;
    public int countAutoIncrease;
    public int costIncrease;
    public int costAutoIncrease;

    public Button lockButton;
    public int deLockCost;

    void Start()
    {
        StartCoroutine(AutoIncrease());
        costIncreaseT.text = costIncrease.ToString();
        costAutoIncreaseT.text = costAutoIncrease.ToString();
    }
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            UpgradePanel.SetActive(true);
            eventData.Reset();
        }
    }
    public void CloseUpgradePanel()
    {
        UpgradePanel.SetActive(false);
    }

    public virtual void OnClickMine()
    {
        if (mineIndex == 0) Storage.storage[mineIndex] += countIncrease;
        else if (Storage.storage[mineIndex - 1] >= countIncrease * 2)
        {
            Storage.storage[mineIndex - 1] -= countIncrease * 2;
            Storage.storage[mineIndex] += countIncrease;
        }
    }
    public virtual void OnClickMineIncreaseUpgrade()
    {
        if (Storage.storage[mineIndex] >= costIncrease)
        {
            Storage.storage[mineIndex] -= costIncrease;
            costIncrease *= 3;
            costIncreaseT.text = costIncrease.ToString();
            countIncrease += countIncrease;
            countIncreaseT.text = countIncrease.ToString();
        }
    }
    public virtual void OnClickMineAutoIncreaseUpgrade()
    {
        if (Storage.storage[mineIndex] >= costAutoIncrease)
        {
            
            Storage.storage[mineIndex] -= costAutoIncrease;
            costAutoIncrease *= 3;
            costAutoIncreaseT.text = costAutoIncrease.ToString();
            if (countAutoIncrease == 0) countAutoIncrease = 1;
            else countAutoIncrease += Convert.ToInt32(countAutoIncrease * 1.3);
            countAutoIncreaseT.text = countAutoIncrease.ToString();
        }
    }
    public virtual void AutoCraft()
    {
        if (mineIndex == 0) Storage.storage[mineIndex] += countAutoIncrease;
        else if (Storage.storage[mineIndex - 1] >= 2 * countAutoIncrease)
        {
            Storage.storage[mineIndex - 1] -= 2 * countAutoIncrease;
            Storage.storage[mineIndex] += countAutoIncrease;
        }
    }
    IEnumerator AutoIncrease()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);
            AutoCraft();
        }
    }
    public void DeLockMine()
    {
        if (Storage.hexs[mineIndex] & Storage.cMoney >= deLockCost)
        {
            Storage.cMoney -= deLockCost;
            lockButton.gameObject.SetActive(false);
            Debug.Log("delock");
        }
    }
}

