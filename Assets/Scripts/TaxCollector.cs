using UnityEngine;

public class TaxCollector : Building
{

    private int power = 2;

    static int[] hapynesFromPower = { 0, 0, -1, -2, -3, -4, -5, -6, -7 };
    static int[] goldFromPower =    { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


    public override void Select(Vector3Int position, uint id)
    {
        power++;
        power = Mathf.Clamp(power, 0, 8);

        happinessGain = hapynesFromPower[power];
        moneyGain = goldFromPower[power];

        Debug.Log("new production of tax collector: " + happinessGain + " / " + moneyGain);
    }

    public override void Cancel(Vector3Int position, int id)
    {
        power--;
        power = Mathf.Clamp(power, 0, 8);

        happinessGain = hapynesFromPower[power];
        moneyGain = goldFromPower[power];
        Debug.Log("new production of tax collector: " +happinessGain + " / "+ moneyGain);

    }




}
