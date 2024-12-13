using UnityEngine;
using System.Collections.Generic;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI[] moneyText = new TextMeshProUGUI[2];
    public TextMeshProUGUI[] happinessText = new TextMeshProUGUI[2];
    public Image[] happinessIcon = new Image[2];

    Sprite HAPINIS5, HAPINIS4, HAPINIS3, HAPINIS2,HAPINIS1;
    private void Start()
    {
        ResourceManager.CountChange.AddListener(CounterUpdate);
        ResourceManager.CountChange.AddListener(IconUpdate);

        HAPINIS5 = Resources.Load<Sprite>("Happiness5");  // :D
        HAPINIS4 = Resources.Load<Sprite>("Happiness4");  // :)
        HAPINIS3 = Resources.Load<Sprite>("Happiness3");  // :|
        HAPINIS2 = Resources.Load<Sprite>("Happiness2");  // :(
        HAPINIS1 = Resources.Load<Sprite>("Happiness1");  // >:(
    }
    private void IconUpdate(CounterValues vals) {
        const int happiness = 28;
        switch (vals.happiness)
        {
                case >= happiness * 2:
                    happinessIcon[vals.player].sprite = HAPINIS5;
                    break;
                case > happiness:
                    happinessIcon[vals.player].sprite = HAPINIS4;
                    break;
                case <= 0 - happiness:
                    happinessIcon[vals.player].sprite = HAPINIS1;
                    break;
                case < 0:
                    happinessIcon[vals.player].sprite = HAPINIS2;
                    break;
                case <= happiness/2:
                    happinessIcon[vals.player].sprite = HAPINIS3;
                    break;
                

        }

    }
    private void CounterUpdate(CounterValues vals)
    {
        moneyText[vals.player].text = vals.gold.ToString();
        happinessText[vals.player].text = vals.happiness.ToString();
    }
}

public struct CounterValues
{
    public int gold;
    public int happiness;
    public uint player;
    public int happiness_gain;

    public CounterValues(int gold, int happiness, uint player, int happiness_gain)
    {
        this.gold = gold;
        this.happiness = happiness;
        this.player = player;
        this.happiness_gain = happiness_gain;
    }
}