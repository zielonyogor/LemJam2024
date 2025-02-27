using UnityEngine;

public class BuildingProxy : Building
{

    Building building = null;

    static int index = 0;

    //[SerializeField] GameObject buildPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public override void Select(Vector3Int position, uint id)
    {



        Tool stupidTool = GridManager.Instance.goofyAssTools[id];
        if (building != null)
        {


            if (stupidTool != null)
            {
                Debug.Log("using tool");
                stupidTool.UseTool(building);

                if (stupidTool.targetEnemy)
                    PlayerStateManager.Instance.ChangeStateOfPlayer(id, State.Basic);
                GridManager.Instance.goofyAssTools[id] = null;


            }
            else
            {
                Debug.Log("blagam00");
                building.Select(position, id);
            }
        }
        else if (stupidTool == null)
        {
            {
                building = Instantiate(GridManager.Instance.goofyAssData[position.z]);
                Vector2 newPos = GridManager.Instance.GetGridPosition(position);
                building.transform.position = newPos;
                Instantiate(Globals.Instance.placeBuildingParticle, building.transform.GetChild(0));
                GridManager.Instance.buildingPlaced.Invoke();
                MusicManager.Instance.PlaySelectSound();
                index++;
                building.owner = id;

            }


        }
    }

    public override void Cancel(Vector3Int position, int id)
    {
        Tool stupidTool = GridManager.Instance.goofyAssTools[id];
        if (stupidTool != null)
        {
            GridManager.Instance.goofyAssTools[id] = null;
        }
        building.Cancel(position, id);
        MusicManager.Instance.PlayDeclineSound();
    }
}