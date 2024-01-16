using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Hex : MonoBehaviour, IPointerClickHandler
{
    public bool owner = true;
    public int enemyGrey;
    public Text enemyGreyT;
    public int enemyGreyInc;

    public Text myPowerT;
    public int myPower;
    public Text enemyPowerT;
    public int enemyPower;


    public GameObject hexPanel;
    public Slider sliderGrey;
    public Text valueGrey;
    public Slider sliderWhite;
    public Text valueWhite;
    public Slider sliderGreen;
    public Text valueGreen;

    void Start()
    {
        StartCoroutine(AutoIncrease());
    }
    void Update()
    {
        enemyGreyT.text = enemyGrey.ToString();
        enemyPowerT.text = enemyPower.ToString();
        myPowerT.text = myPower.ToString();


        valueGrey.text = Math.Truncate(sliderGrey.value * Storage.cGrey).ToString();
        valueWhite.text = Math.Truncate(sliderWhite.value * Storage.cWhite).ToString();
        valueGreen.text = Math.Truncate(sliderGreen.value * Storage.cGreen).ToString();

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("hex click");
            hexPanel.SetActive(true);
            eventData.Reset();
        }
    }
    public void SliderChange()
    {

    }
    public void CloseHexPanel()
    {
        hexPanel.SetActive(false);
    }
    IEnumerator AutoIncrease()
    {
        while (owner)
        {
            yield return new WaitForSecondsRealtime(5);
            enemyGrey += enemyGreyInc;
        }
    }
    public void TurnOfBattle()
    {
        enemyGrey -= Convert.ToInt32(sliderGrey.value * Storage.cGrey);
        Storage.cGrey -= Convert.ToInt32(sliderGrey.value * Storage.cGrey);
        if (enemyGrey < 0)
        {
            enemyGrey = 0;
            owner = false;
            StopAllCoroutines();
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
    public void SendResToHex()
    {

    }
}
