using UnityEngine;

public class cameraControler : MonoBehaviour
{
    [SerializeField] Animation animator;
    private void Start()
    {
        animator = GetComponent<Animation>();
        GridManager.Instance.buildingPlaced.AddListener(startShake);
    }

    void startShake()
    {
        animator.Play();
        Debug.Log("AAAA");

    }
}
