using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.EventSystems.EventTrigger;


public class ResourceManager : MonoBehaviour
{

    public static ResourceManager instance;
    public uint time_stamp = 0;

    public static UnityEvent<CounterValues> CountChange;

    public int[] happiness = new int[2];
    public int[] gold = new int[2];

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(this);
        }

        if (CountChange == null)
            CountChange = new UnityEvent<CounterValues>();

    }
    public void AddResources(HistoryEntry entry)
    {
       
        happiness[entry.player] += entry.happiness_gain;
        gold[entry.player] += entry.gold_gain;
        CountChange.Invoke(new CounterValues(gold[entry.player],happiness[entry.player],entry.player));
    }

    public void SubtractResources(HistoryEntry entry)
    {
        
        happiness[entry.player] -= entry.happiness_gain;
        gold[entry.player] -= entry.gold_gain;
        CountChange.Invoke(new CounterValues(gold[entry.player], happiness[entry.player], entry.player));
    }

    public int GetPlayerWin()
    {
        return happiness[0] > happiness[1] ? 1 : 2;
    }

}
