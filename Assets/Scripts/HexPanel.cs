using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HexPanel : MonoBehaviour
{
    public GameObject hexPanel;
    public Hex[] hexs;
    public Text[] hexCargoPlayerT = new Text[9];
    public Text[] hexCargoEnemyT = new Text[9];
    public Slider[] sliders = new Slider[9];
    public Text[] valueSliders = new Text[9];

    public Button sendResToHex;
    public Text myPowerT;
    public Text enemyPowerT;
    public Text myTurnPowerT;
    public Text enemyTurnPowerT;
    public Text hexMoneyT;

    public void CloseHexPanel()
    {
        foreach (var item in Mapping.map2x)
        {
            item.CloseHexPanel();
        }
    }
    public void SendResToHex()
    {
        foreach (var item in hexs)
        {
            item.SendResToHex();
        }
    }
    void Start()
    {
        
    }
    void Awake()
    {

    }
    void Update()
    {
        
    }
}
