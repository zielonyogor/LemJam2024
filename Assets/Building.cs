using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;
using Unity.VisualScripting;


[System.Serializable]
public class Building : MonoBehaviour
{
    public int moneyGain = 1;
    public int happinessGain = 1;
    public int happinesCostOnBuild = 50;
    public int goldCostOnBuild = 701;

    [SerializeField] private String description = "";
    [SerializeField] private String nameText = "";

    public uint owner = 0;



    public List<HistoryEntry> history = new List<HistoryEntry>();

    public virtual void Start()
    {

        TimeManager.instance.TimeProgressed.AddListener(ProgressTime);
        history.Add(new BuildHistoryEntry(goldCostOnBuild, happinesCostOnBuild, owner, this));


    }

    protected virtual void ProgressTime()
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

        List<HistoryEntry> toDelate = new List<HistoryEntry>();
        foreach (var item in history.Where(X => X.time_stamp >= RevertTime))
        {
            item.Revert();
            toDelate.Add(item);

        }

        foreach (var item in toDelate)
        {
            history.Remove(item);
        }
    }


    public virtual void Select(Vector3Int position, uint id)
    {
        Debug.Log("co do sigmy");

    }
    public virtual void Cancel(Vector3Int position, int id)
    {
        Debug.Log("co do niesigmy");
    }

    public String GetDescription()
    {
        return description;
    }

    public String GetName()
    {
        return nameText;
    }
}

public class HistoryEntry
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

    public virtual void Revert()
    {
        ResourceManager.instance.SubtractResources(this);


    }








}

public class BuildHistoryEntry : HistoryEntry
{

    Building b;
    public BuildHistoryEntry(int gold, int happiness, uint player, Building b) : base(-gold, -happiness, player)
    {

        if (ResourceManager.instance.CheckPlayerResources(player))
        {
            this.b = b;

        }
        else
        {

            GameObject.Destroy(b.gameObject);
            Revert();
        }




    }

    public override void Revert()
    {
        base.Revert();

        if (b != null)
            GameObject.Destroy(b.gameObject);

    }



}
