using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public enum State
{
    Basic,
    TargetOpponent,
    TargetYourself
}

public class PlayerController : MonoBehaviour
{
    public int id = 1;

    PlayerInput playerInput;
    private Vector3Int currentIndex;
    private State currentState;

    public static UnityEvent<Vector3Int> OnPlayerPositionChanged = new UnityEvent<Vector3Int>();

    private void Start()
    {
        currentIndex = new Vector3Int(0, 0, id);
        Vector2 newPosition = GridManager.Instance.GetGridPosition(currentIndex);
        transform.position = newPosition;
        OnPlayerPositionChanged.Invoke(currentIndex);

        currentState = State.Basic;

        playerInput = GetComponent<PlayerInput>();

        timer.Timeout.AddListener(() =>
        {
            playerInput.SwitchCurrentActionMap("Standby");
        });
        MenuPause.PauseOn.AddListener(() =>
        {
            playerInput.SwitchCurrentActionMap("Standby");
        });
        MenuPause.PauseOff.AddListener(() =>
        {
            playerInput.SwitchCurrentActionMap("Player_" + (id + 1));
        });

        GetComponent<Animator>().SetInteger("id", id);
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



        Vector2 newPosition = GridManager.Instance.GetGridPosition(currentIndex);
        transform.position = newPosition;

        if (currentState != State.TargetOpponent)
        {
            OnPlayerPositionChanged.Invoke(currentIndex);
        }

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
            GridManager.Instance.SpawnBuildingAtPosition(new Vector3Int(currentIndex.x, currentIndex.y, id), (uint)id);
        }
        else if (currentState == State.TargetOpponent)
        {
            GridManager.Instance.SpawnBuildingAtPosition(currentIndex, (uint)id);
        }
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        //if (!context.performed) return;

        Debug.Log("cancel was clicked");
        if (currentState == State.TargetOpponent)
        {
            Debug.Log("We are NOT in targeting opps");
            currentIndex.z = id;
            ChangeState(State.Basic);
            Vector2 newPosition = GridManager.Instance.GetGridPosition(currentIndex);
            transform.position = newPosition;
        }
        else
        {
            GridManager.Instance.CancelBuilding(currentIndex, (uint)id);
        }
    }

    public void ChangeState(State newState)
    {
        currentState = newState;
        if (newState == State.TargetOpponent)
        {
            currentIndex.z = id == 0 ? 1 : 0;
        }
        else
        {
            currentIndex.z = id == 0 ? 0 : 1;
        }

        Vector2 newPosition = GridManager.Instance.GetGridPosition(currentIndex);
        transform.position = newPosition;
    }
}
