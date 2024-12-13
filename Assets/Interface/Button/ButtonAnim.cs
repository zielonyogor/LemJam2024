using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnim : MonoBehaviour
{

    [SerializeField] private Image Background;
    [SerializeField] private Sprite Normal;

    [SerializeField] private Sprite Hover;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("hover");
        Background.sprite = Hover;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
