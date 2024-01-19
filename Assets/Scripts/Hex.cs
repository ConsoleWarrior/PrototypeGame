using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hex : MonoBehaviour, IPointerClickHandler
{
    public HexPanel hexPanel;
    public int hexIndex;
    public int[] hexCargoPlayer = new int[9];
    public int[] hexCargoEnemy = new int[9];

    public bool owner = false;
    public GameObject hexPanelObject;
    public int myPower;
    public int enemyPower;
    public int enemyTurnPower;
    public int myTurnPower;
    public int hexMoney;

    void Start()
    {
        StartCoroutine(AutoIncreaseEnemyCargo());
        StartCoroutine(Refresh());
    }
    void FixedUpdate()
    {
        if (hexPanel != null) UpdatePanel();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left & !hexPanelObject.activeSelf)
        {
            hexPanelObject.SetActive(true);
            hexPanel = hexPanelObject.GetComponent<HexPanel>();
            eventData.Reset();
        }
    }
    public void CloseHexPanel()
    {
        hexPanelObject.SetActive(false);
        hexPanel = null;
    }
    void UpdatePanel()
    {
        hexPanel.hexMoneyT.text = "+" + hexMoney.ToString();
        hexPanel.enemyPowerT.text = enemyPower.ToString();
        hexPanel.enemyTurnPowerT.text = "+" + enemyTurnPower.ToString();
        hexPanel.myPowerT.text = myPower.ToString();
        hexPanel.myTurnPowerT.text = "+" + myTurnPower.ToString();
        for (int i = 0; i < 9; i++)
        {
            hexPanel.hexCargoPlayerT[i].text = hexCargoPlayer[i].ToString();
            hexPanel.hexCargoEnemyT[i].text = hexCargoEnemy[i].ToString();
            hexPanel.valueSliders[i].text = Math.Truncate(hexPanel.sliders[i].value * Storage.storage[i]).ToString();
        }
    }
    IEnumerator AutoIncreaseEnemyCargo()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(5);
            if (owner)
                for (int i = 0; i < hexIndex; i++)
                {
                    hexCargoEnemy[i] += hexIndex * 5;
                }
            else for (int i = 0; i < hexIndex; i++)
                {
                    hexCargoEnemy[i] += hexIndex * 10;
                }
        }
    }
    IEnumerator Refresh()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);
            myTurnPower = CalculatePower(hexCargoPlayer);
            myPower += myTurnPower;
            enemyTurnPower = CalculatePower(hexCargoEnemy);
            enemyPower += enemyTurnPower;
            TurnOfBattle();
            if (owner) Storage.cMoney += hexMoney;
        }
    }
    public int CalculatePower(int[] cargo)
    {
        int power = 0; int price = 1;
        for (int i = 0; i < cargo.Length; i++)
        {
            power += cargo[i] / 10 * price;
            price = (price + i) * 2;
            cargo[i] -= cargo[i] / 10;
        }
        return power;
    }
    public void TurnOfBattle()
    {
        if (myPower <= enemyPower)
        {
            enemyPower -= myPower;
            myPower = 0;
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            owner = false;
        }
        if (myPower > enemyPower)
        {
            myPower -= enemyPower;
            enemyPower = 0;
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            owner = true;
            Storage.hexs[hexIndex] = true;
        }
    }
    public void SendResToHex()
    {
        if (hexPanel != null)
            for (int i = 0; i < 9; i++)
            {
                hexCargoPlayer[i] += Convert.ToInt32(hexPanel.sliders[i].value * Storage.storage[i]);
                Storage.storage[i] -= Convert.ToInt32(hexPanel.sliders[i].value * Storage.storage[i]);
            };
    }
}
