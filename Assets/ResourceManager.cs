using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;
    public uint time_stamp = 0;


    public int[] happiness = new int[2];
    public int[] gold = new int[2];

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            

        }
        else
        {
            Destroy(this);
        }


    }

    public void AddResources(HistoryEntry entry)
    {
        happiness[entry.player] += entry.happiness_gain;
        gold[entry.player] += entry.gold_gain;
    }

    public void SubtractResources(HistoryEntry entry)
    {
        happiness[entry.player] -= entry.happiness_gain;
        gold[entry.player] -= entry.gold_gain;

    }

    // Update is called once per frame
    void Update()
    {
        


    }
}
