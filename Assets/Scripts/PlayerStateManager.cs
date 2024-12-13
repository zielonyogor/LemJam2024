using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStateManager : MonoBehaviour
{
    public static PlayerStateManager Instance { get; private set; }

    [SerializeField] PlayerController player_1, player_2;

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

    public void ChangeStateOfPlayer(uint id, State newState)
    {
        if (id == 0)
        {
            player_1.ChangeState(newState);
        }
        else
        {
            player_2.ChangeState(newState);
        }
    }
}