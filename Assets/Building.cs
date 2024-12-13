using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class Building : MonoBehaviour
{
    [SerializeField] private int moneyGain = 1;
    [SerializeField] private int happinessGain = 1;
    public uint owner = 0;



    public List<HistoryEntry> history = new List<HistoryEntry>();

    private void Start()
    {
        TimeManager.instance.TimeProgressed.AddListener(ProgressTime);
    }

    void ProgressTime()
    {
        
        if (moneyGain != 0 || happinessGain != 0)
            history.Add(new HistoryEntry(moneyGain, happinessGain, owner));

    }

    public void Test()
    {
        Debug.Log("test building spawning");
    }


    public void TerroristAttack(int timeReversed)
    {

        uint currentTimeStamp = TimeManager.instance.time_stamp;


        uint RevertTime = currentTimeStamp - (uint)timeReversed;    

    }


    public virtual void Select(Vector3Int position)
    {
        Debug.Log("co do sigmy");
    }
}

public struct HistoryEntry
{
    public uint time_stamp;
    public int happiness_gain;
    public int gold_gain;
    public uint player;

    public HistoryEntry(int gold, int happiness, uint player)
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
