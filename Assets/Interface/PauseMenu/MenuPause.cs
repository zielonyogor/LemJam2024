using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuPause : MonoBehaviour
{
    private bool Pause = false;
    public static UnityEvent PauseOn = new UnityEvent(); 
    public static UnityEvent PauseOff = new UnityEvent(); 
    
    public void ReturnToGame()
    {
        Pause = true;
        transform.GetChild(0).gameObject.SetActive(false);
        PauseOff.Invoke();
    }

    public void SwitchPause()
    {
        if(Pause)
        {
            Pause = false;
            transform.GetChild(0).gameObject.SetActive(true);
            PauseOn.Invoke();
            return;
        }
        ReturnToGame();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnExit(InputAction.CallbackContext context)
    {
        if(!context.performed) return;
        SwitchPause();
    }

}
