using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }

    public Vector2Int player1GridStartIndex = new Vector2Int(-5, 3);
    public Vector2Int player2GridStartIndex = new Vector2Int(2, -1);

    public UnityEvent buildingPlaced = new UnityEvent();


    public Building[] goofyAssData = new Building[2];

    public Tool[] goofyAssTools = new Tool[2];
    public Building[] buildingPlacement1 = new Building[9];
    public Building[] buildingPlacement2 = new Building[9];





    public Building[,,] gridMatrix = new BuildingProxy[2, 3, 3];

    [SerializeField] private GridLayout gridLayout;
    private float gap;

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        gap = gridLayout.cellGap.x;
    }

    private void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {

                    gridMatrix[i, j, k] = new GameObject("gridProxy").AddComponent<BuildingProxy>();
                }
            }
        }

    }

    public void SpawnBuildingAtPosition(Vector3Int position, uint id)
    {
        int posX, posY;
        if (position.z == 0) // which player - Z
        {
            posX = position.x + player1GridStartIndex.x;
            posY = position.y + player1GridStartIndex.y;
        }
        else
        {
            posX = position.x + player2GridStartIndex.x;
            posY = position.y + player2GridStartIndex.y;
        }
        Vector3 newCellPos = gridLayout.CellToWorld(new Vector3Int(posX, posY, 0));
        newCellPos.y -= gap;
        //Building newBuilding = Instantiate(buildingPrefab, newCellPos, Quaternion.identity);
        //gridMatrix[position.z, position.x, position.y] = newBuilding;
        Debug.Log(position);
        goofyAssData[position.z] = position.z == 0 ? buildingPlacement1[3 * position.x - position.y] : buildingPlacement2[3 * position.x - position.y];
        gridMatrix[position.z, position.x, -position.y].Select(position, id);

    }

    public void CancelBuilding(Vector3Int position, uint id)
    {
        //Building newBuilding = Instantiate(buildingPrefab, newCellPos, Quaternion.identity);
        //gridMatrix[position.z, position.x, position.y] = newBuilding;
        gridMatrix[position.z, position.x, -position.y].Cancel(position, (int)id);

    }

    public void SendTerroristAttack(Vector3Int position)
    {
        //Debug.Log(position);
        // goofyAssTools[position.z].UseTool(gridMatrix[position.z, position.x, -position.y]);
    }

    public Building GetBuildingInfo(Vector3Int position)
    {
        return position.z == 0 ? buildingPlacement1[3 * position.x - position.y] : buildingPlacement2[3 * position.x - position.y];
    }

    public Vector2 GetGridPosition(Vector3Int position)
    {

        int posX, posY;
        if (position.z == 0)
        {
            posX = position.x + player1GridStartIndex.x;
            posY = position.y + player1GridStartIndex.y;
        }
        else
        {
            posX = position.x + player2GridStartIndex.x;
            posY = position.y + player2GridStartIndex.y;
        }

        Vector3 newCellPos = gridLayout.CellToWorld(new Vector3Int(posX, posY, 0));

        Vector2 returnVector = new Vector2(newCellPos.x, newCellPos.y - gap);


        return returnVector;

    }
}