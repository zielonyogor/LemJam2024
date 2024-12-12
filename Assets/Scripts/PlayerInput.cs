using UnityEngine;
using UnityEngine.InputSystem;

public enum State
{
    Basic,
    TargetOpponent,
    TargetYourself
}

public class PlayerInput : MonoBehaviour
{
    public int id = 1;
    private Vector3Int currentIndex;
    private State currentState;

    private void Start()
    {
        currentIndex = new Vector3Int(0, 0, id);
        Vector2 newPosition = GridManager.Instance.GetGridPosition(currentIndex);
        transform.position = newPosition;

        currentState = State.Basic;
    }

    public void OnPlayerMove(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Vector2 moveVector = context.ReadValue<Vector2>();

        currentIndex += new Vector3Int((int)moveVector.x, (int)moveVector.y, 0);

        if (currentIndex.x >= 3) { currentIndex.x = 2; }
        if (currentIndex.x < 0) currentIndex.x = 0;
        if (currentIndex.y <= -3) currentIndex.y = -2;
        if (currentIndex.y > 0) currentIndex.y = 0;

        Debug.Log("Current player Local Position: " + currentIndex);

        Vector2 newPosition = GridManager.Instance.GetGridPosition(currentIndex);
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
        if (!context.performed) return;

        if (currentState == State.Basic)
        {
            GridManager.Instance.SpawnBuildingAtPosition(new Vector3Int(currentIndex.x, currentIndex.y, id));
        }
    }

    public void ChangeState(State newState)
    {
        currentState = newState;
        if (newState == State.TargetOpponent)
        {
            currentIndex.z = id == 1 ? 2 : 1;
        }
        else
        {
            currentIndex.z = id == 1 ? 1 : 2;
        }
    }
}
