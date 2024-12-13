using UnityEngine;

public class CentrumRekurencji : Building
{

    public int Cooldown;
    private int currentCooldown;
    public int happynesGainPerActivation =1;
    public int goldGainPerActivation = 1;
    public override void Cancel(Vector3Int position, int id)
    {
       
    }

    public override void Select(Vector3Int position, uint id)
    {
        
    }


    protected override void ProgressTime()
    {
        currentCooldown -= 1;
        if (currentCooldown < 0)
        {

            currentCooldown = Cooldown;
            moneyGain += goldGainPerActivation;
            happinessGain += happynesGainPerActivation;




        }

    }


}
