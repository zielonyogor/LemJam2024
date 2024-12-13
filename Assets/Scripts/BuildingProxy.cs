using UnityEngine;

public class BuildingProxy : Building
{

    Building building = null;

    static int index = 0;

    //[SerializeField] GameObject buildPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public override void Select(Vector3Int position)
    {
        if (building != null)
        {
            building.Select(position);
        }
        else
        {
            building = Instantiate(GridManager.Instance.goofyAssData[position.z]);
            Vector2 newPos = GridManager.Instance.GetGridPosition(position);
            building.transform.position = newPos;
            Instantiate(Globals.Instance.placeBuildingParticle, building.transform.GetChild(0));

            index++;
            building.owner = (uint)position.z;

        }


    }
}
