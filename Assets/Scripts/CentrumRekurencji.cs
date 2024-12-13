using UnityEngine;

public class CentrumRekurencji : Building
{

    public override void Cancel(Vector3Int position, int id)
    {
       
    }

    public override void Select(Vector3Int position, uint id)
    {
        
    }


    protected override void ProgressTime()
    {
        base.ProgressTime();
        if(TimeManager.instance.time_stamp % 20 == 0)
        {
            moneyGain++;
        }

    }


}
