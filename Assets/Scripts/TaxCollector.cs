using UnityEngine;

public class TaxCollector : Building
{

    private int power;

    static int[] hapynesFromPower = { 7, 5, 3, 2, 1, -1, -2, 5, -7 };
    static int[] goldFromPower =    { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


    public override void Select(Vector3Int position, uint id)
    {
        power++;
        power = Mathf.Clamp(power, 1, 9);

        happinessGain = hapynesFromPower[power];
        moneyGain = goldFromPower[power];

    }

}
