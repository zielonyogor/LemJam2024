using Unity.VisualScripting;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public ParticleSystem placeBuildingParticle;
    public static Globals Instance { get; private set; }
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

}
