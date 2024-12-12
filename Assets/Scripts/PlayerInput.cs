using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public int id = 1;

    private Vector2Int currentIndex = new Vector2Int(0, 0);

    private void Start()
    {
        Vector2 newPosition = GridManager.Instance.GetGridPosition(currentIndex, id);
        transform.position = newPosition;
    }

    public void OnPlayerMove(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Vector2 moveVector = context.ReadValue<Vector2>();

        currentIndex += new Vector2Int((int)moveVector.x, (int)moveVector.y);

        if (currentIndex.x >= 3) { currentIndex.x = 2; }
        if (currentIndex.x < 0) currentIndex.x = 0;
        if (currentIndex.y <= -3) currentIndex.y = -2;
        if (currentIndex.y > 0) currentIndex.y = 0;

        Debug.Log("Current player Local Position: " + currentIndex);

        Vector2 newPosition = GridManager.Instance.GetGridPosition(currentIndex, id);
        transform.position = newPosition;

        // if (id == 1)
        // {
        //     Debug.Log("plaeyr 1 move");
        // }
        // else
        // {
        //     Debug.Log("Player 2 move");
        // }
    }

    public void OnAccept(InputAction.CallbackContext context)
    {
        GridManager.Instance.SpawnBuildingAtPosition(new Vector3Int(currentIndex.x, currentIndex.y, 1));
    }

}
