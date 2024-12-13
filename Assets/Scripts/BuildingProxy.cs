using UnityEngine;

public class BuildingProxy : Building
{

    Building building = null;

    static int index =0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void  Select()
    {
        Debug.Log("building proxy is selected");
        if (building != null)
        {
            building.Select();
        }
        else
        {
            if(index %2 == 0)
            {
                building = new GameObject("AAAA").AddComponent<Building>();
            }
            else
            {
                building = new GameObject("BBBB").AddComponent<BombFactory>();
            }

        }


    }
}
