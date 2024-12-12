using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public int id = 1;

    public int gridWidth = 4;


    void Start()
    {

    }


    public void OnPlayerMove(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Vector2 moveVector = context.ReadValue<Vector2>();
        Vector3Int positionVector = new Vector3Int((int)moveVector.x, (int)moveVector.y, 0);
        transform.position += positionVector * gridWidth;

        if (id == 1)
        {
            Debug.Log("plaeyr 1 move");
        }
        else
        {
            Debug.Log("Player 2 move");
        }
    }

}
