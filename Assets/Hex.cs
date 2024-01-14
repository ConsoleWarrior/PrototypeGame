using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Hex : MonoBehaviour, IPointerClickHandler
{
    public GameObject hexPanel;
    public Slider sliderHexPanel;
    public Text countGrey;
    //public Mine grey;

    void Update()
    {
        countGrey.text = Math.Truncate(sliderHexPanel.value * Storage.cGrey).ToString();
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
}
