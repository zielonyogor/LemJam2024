using UnityEngine;

public class Cepelin : Building
{


    public override void Select(Vector3Int position, uint id)
    {
        GridManager.Instance.goofyAssTools[id] = new SmellyBomb();
        Debug.Log("aaaaaa bomba �mierdziszka ;)");
        PlayerStateManager.Instance.ChangeStateOfPlayer(owner, State.TargetOpponent);
    }

}
