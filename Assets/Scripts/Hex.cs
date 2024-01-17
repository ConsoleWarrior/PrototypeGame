using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hex : MonoBehaviour, IPointerClickHandler
{
    public int hexIndex;
    public int[] hexCargoPlayer = new int[9];
    public Text[] hexCargoPlayerT = new Text[9];
    public int[] hexCargoEnemy = new int[9];
    public Text[] hexCargoEnemyT = new Text[9];
    public Slider[] sliders = new Slider[9];
    public Text[] valueSliders = new Text[9];
    //public int[] autoIncreaseEnemy = new int[9];
    //public Text[] autoIncreaseEnemyT = new Text[9];

    public bool owner = false;
    public GameObject hexPanel;
    public int myPower;
    public Text myPowerT;
    public int enemyPower;
    public Text enemyPowerT;
    public int enemyTurnPower;
    public Text enemyTurnPowerT;
    public int myTurnPower;
    public Text myTurnPowerT;


    void Start()
    {
        StartCoroutine(AutoIncreaseEnemyCargo());
        StartCoroutine(Refresh());

    }
    void Update()
    {
        enemyPowerT.text = enemyPower.ToString();
        myPowerT.text = myPower.ToString();

        for (int i = 0; i < 9; i++)
        {
            valueSliders[i].text = Math.Truncate(sliders[i].value * Storage.storage[i]).ToString();
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            hexPanel.SetActive(true);
            eventData.Reset();
        }
    }
    public void CloseHexPanel()
    {
        hexPanel.SetActive(false);
    }
    IEnumerator AutoIncreaseEnemyCargo()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(5);
            if (owner)
                for (int i = 0; i < hexIndex; i++)
                {
                    hexCargoEnemy[i] += hexIndex * 10;
                }
            else for (int i = 0; i < hexIndex; i++)
                {
                    hexCargoEnemy[i] += hexIndex * 20;
                }
        }
    }
    IEnumerator Refresh()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(2);
            myTurnPower = CalculatePower(hexCargoPlayer);
            myPower += myTurnPower;
            enemyTurnPower = CalculatePower(hexCargoEnemy);
            enemyPower += enemyTurnPower;
            for (int i = 0; i < 9; i++)
            {
                hexCargoPlayerT[i].text = hexCargoPlayer[i].ToString();
                myTurnPowerT.text = "+" + myTurnPower.ToString();
                hexCargoEnemyT[i].text = hexCargoEnemy[i].ToString();
                enemyTurnPowerT.text = "+" + enemyTurnPower.ToString();
            }
            TurnOfBattle();
        }
    }
    public int CalculatePower(int[] cargo)
    {
        int power = 0; int price = 1;
        for (int i = 0; i < cargo.Length; i++)
        {
            power += cargo[i] / 10 * price;
            price = price * 2 + 1;
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
        }
    }
    public void SendResToHex()
    {
        for (int i = 0; i < 9; i++)
        {
            hexCargoPlayer[i] += Convert.ToInt32(sliders[i].value * Storage.storage[i]);
            Storage.storage[i] -= Convert.ToInt32(sliders[i].value * Storage.storage[i]);
        }
    }
}
