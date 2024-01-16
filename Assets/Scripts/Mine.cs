using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mine : MonoBehaviour, IPointerClickHandler
{

    public Text countIncreaseT;
    public Text countAutoIncreaseT;
    public Text costIncreaseT;
    public Text costAutoIncreaseT;

    public int countIncrease = 1;
    public int countAutoIncrease = 0;
    public int costIncrease = 10;
    public int costAutoIncrease = 30;
    public GameObject UpgradePanel;

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
        Storage.cGrey += countIncrease;
    }
    public virtual void OnClickMineIncreaseUpgrade()
    {
        if (Storage.cGrey >= costIncrease)
        {
            Storage.cGrey -= costIncrease;
            costIncrease *= 3;
            costIncreaseT.text  = costIncrease.ToString();
            countIncrease++;
            countIncreaseT.text = countIncrease.ToString();
        }
    }
    public virtual void OnClickMineAutoIncreaseUpgrade()
    {
        if (Storage.cGrey >= costAutoIncrease)
        {
            Storage.cGrey -= costAutoIncrease;
            costAutoIncrease *= 3;
            costAutoIncreaseT.text = costAutoIncrease.ToString();
            countAutoIncrease++;
            countAutoIncreaseT.text = countAutoIncrease.ToString();
        }
    }
    public virtual void Craft()
    {

        Storage.cGrey += countAutoIncrease;

    }
    IEnumerator AutoIncrease()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);
            Craft();
        }
    }

}

