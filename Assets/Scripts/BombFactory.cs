using UnityEngine;

public class BombFactory : Building
{

    public override void Start()
    {

        base.Start();
    }

    public override void Select(Vector3Int position, uint id)
    {
        GridManager.Instance.goofyAssTools[id] = new LittleBoy();
        Debug.Log("aaaaaa bomba");
        PlayerStateManager.Instance.ChangeStateOfPlayer(owner, State.TargetOpponent);
    }
}
