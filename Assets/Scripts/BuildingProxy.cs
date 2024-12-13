using UnityEngine;

public class BuildingProxy : Building
{

    Building building = null;

    static int index =0;

    //[SerializeField] GameObject buildPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void  Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void  Select(Vector3Int position)
    {

        

        if (building != null)
        {
            Tool stupidTool = GridManager.Instance.goofyAssTools[position.z];
            if (stupidTool != null)
            {
                stupidTool.UseTool(building);
                
            }else
                building.Select(position);
        }
        else
        {
            building = Instantiate(GridManager.Instance.goofyAssData[position.z]);
            building.transform.position = GridManager.Instance.GetGridPosition(position);

            index++;
            building.owner = (uint)position.z;

        }


    }
}
