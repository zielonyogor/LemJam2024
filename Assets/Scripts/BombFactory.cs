using UnityEngine;

public class BombFactory : Building
{

    public override void Start()
    {
        
        base.Start();
    }

    public override void Select(Vector3Int position)
    {
        GridManager.Instance.goofyAssTools[position.z] = new LittleBoy();
        Debug.Log()

    }
}
