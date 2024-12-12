using NUnit.Framework;
using System;
using UnityEngine;

using System.Collections.Generic;
using UnityEngine.UIElements;

public abstract class Building : MonoBehaviour
{
    [SerializeField] private int moneyGain =0;
    [SerializeField] private int happynesGain =0;
    private uint ovner;



    public List<HistoryEntry> history = new List<HistoryEntry>();
    

    void progress_time()
    {
        if(moneyGain != 0 || happynesGain != 0)
            history.Add(new HistoryEntry(moneyGain, happynesGain,ovner));

    }
}

public struct HistoryEntry
{
    public uint time_stamp;
    public int happiness_gain;
    public int gold_gain;
    public uint player;

    public HistoryEntry(int gold, int happiness,uint player)
    {
            time_stamp = TimeManager.instance.time_stamp;
            happiness_gain = happiness;
            gold_gain = gold;
            this.player = player;
            ResourceManager.instance.AddResources(this);

    }

    public void Revert()
    {
        ResourceManager.instance.SubtractResources(this);


    }






}
