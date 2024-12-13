using UnityEngine;

public class Cepelin : Building
{


    public override void Select(Vector3Int position, uint id)
    {
        GridManager.Instance.goofyAssTools[id] = new SmellyBomb();
        Debug.Log("aaaaaa bomba œmierdziszka ;)");
        PlayerStateManager.Instance.ChangeStateOfPlayer(owner, State.TargetOpponent);
    }

}
