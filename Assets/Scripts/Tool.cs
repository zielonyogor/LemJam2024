using UnityEngine;

public class Tool
{
    public bool targetEnemy = false;


    public virtual void UseTool(Building building)
    {
        Debug.LogError("TO CHYBA NIE MA  SENSA");

    }

}

public class LittleBoy : Tool
{

    public LittleBoy()
    {
        targetEnemy = true;
    }

    const int TIME_RECURSION_TIME_RECURSION_TIME_RECURSION_TIME_RECURSION = 10;

    public override void UseTool(Building building)
    {
        Debug.Log("bombastycznie");

        building.TerroristAttack(TIME_RECURSION_TIME_RECURSION_TIME_RECURSION_TIME_RECURSION);

        GridManager.Instance.buildingPlaced.Invoke();
        
    }
}


public class SmellyBomb : Tool
{
    public SmellyBomb()
    {
        targetEnemy = true;
    }

    public override void UseTool(Building building)
    {
        Debug.Log("bombastycznie");

        building.happinessGain -= 3;

        GridManager.Instance.buildingPlaced.Invoke();

    }
}



