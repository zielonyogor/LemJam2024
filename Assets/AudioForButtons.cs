using UnityEngine;
using UnityEngine.UI;


public class AudioForButtons : MonoBehaviour
{
    [SerializeField] private Button[] buttonsSelect;

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

    public void Bind(GameObject manager)
    {
        Debug.Log("bindowanie");
        foreach (Button button in buttonsSelect)
        {
            button.onClick.AddListener(delegate { btnClicked("param"); }); 
        }
       
        
    }
    public void btnClicked(string param)
    {
            Debug.Log("foo " + param);
    }
}
