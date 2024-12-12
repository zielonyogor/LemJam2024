using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }

    public Vector2Int player1GridStartIndex = new Vector2Int(-5, 3);
    public Vector2Int player2GridStartIndex = new Vector2Int(2, -1);

    public int[,,] gridMatrix = new int[2, 3, 3];

    private GridLayout gridLayout;
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
    }

    private void Start()
    {
        gridLayout = GetComponent<GridLayout>();
        gap = gridLayout.cellGap.x;
        Debug.Log(gap);
    }
    public Vector2 GetGridPosition(Vector2Int position, int playerId)
    {
        int posX, posY;
        if (playerId == 1)
        {
            posX = position.x + player1GridStartIndex.x;
            posY = position.y + player1GridStartIndex.y;
        }
        else
        {
            posX = position.x + player2GridStartIndex.x;
            posY = position.y + player2GridStartIndex.y;
        }
        Debug.Log(posX + " : " + posY);
        Vector3 newCellPos = gridLayout.CellToWorld(new Vector3Int(posX, posY, 0));

        Vector2 returnVector = new Vector2(newCellPos.x, newCellPos.y - gap);
        Debug.Log(returnVector);
        return returnVector;



    }



}
