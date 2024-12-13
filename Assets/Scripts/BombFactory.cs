using UnityEngine;

public class BombFactory : Building
{


    public override void Select(Vector3Int position)
    {
        Debug.Log("zaraz wystrzeli ;)");
    }
}
