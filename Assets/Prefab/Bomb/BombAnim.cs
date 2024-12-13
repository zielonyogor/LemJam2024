using UnityEngine;

public class BombAnim : MonoBehaviour
{
    [SerializeField] private GameObject BombObject;

    [SerializeField] private Animator animator; 

    [SerializeField] private MenuPause PauseMenu;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PauseMenu != null)
        {
            LinkPause(PauseMenu);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            Destroy(gameObject);
        }
    }
    public void LinkPause(MenuPause PauseObj)
    {
        PauseMenu = PauseObj;
        MenuPause.PauseOn.AddListener(()=>{StopAnim(true);});
        MenuPause.PauseOff.AddListener(()=>{StopAnim(false);});
    }

    private void StopAnim(bool stop)
    {
        animator.gameObject.GetComponent<Animator>().enabled = !stop;
    }
}
