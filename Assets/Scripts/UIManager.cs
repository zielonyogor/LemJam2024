using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI[] moneyText = new TextMeshProUGUI[2];
    public TextMeshProUGUI[] happinessText = new TextMeshProUGUI[2];
   

    private void Start()
    {
        ResourceManager.CountChange.AddListener(CounterUpdate);

    }
    private void CounterUpdate(CounterValues vals)
    {
        moneyText[vals.player].text = vals.gold.ToString();
        happinessText[vals.player].text = vals.happiness.ToString();
        Debug.Log("COUNT CHANGE!");

    }   
}

public struct CounterValues
{
    public int gold;
    public int happiness;
    public uint player;

    public CounterValues(int gold, int happiness, uint player) 
    {
        this.gold = gold;
        this.happiness = happiness;
        this.player = player;

    }
}