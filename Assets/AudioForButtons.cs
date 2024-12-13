using UnityEngine;
using UnityEngine.UI;


public class AudioForButtons : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

    public static AudioForButtons Instance { get; private set; }

    void Awake()
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

    public void Bind()
    {
        Debug.Log("bindowanie");
    }
}
