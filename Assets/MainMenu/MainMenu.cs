using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuUI;
    [SerializeField] private GameObject OptionsUI;



    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Options()
    {
        OptionsUI.SetActive(true);
        MainMenuUI.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void back()
    {
        OptionsUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }

    void Start()
    {
        back();
    }
}
