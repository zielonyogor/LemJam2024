using UnityEngine;

public class Sklep : Building
{
    [SerializeField] private  int goldGainPerSelect;
    [SerializeField] private  int happinesGainPerSelect;


    public override void Cancel(Vector3Int position, int id)
    {
        Debug.Log("hcialbys frajerze");

    }

    public override void Select(Vector3Int position, uint id)
    {
        history.Add(new HistoryEntry(goldGainPerSelect, happinesGainPerSelect, id));
    }



}
