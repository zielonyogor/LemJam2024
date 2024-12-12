using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuUI;
    [SerializeField] private GameObject OptionsUI;
    [SerializeField] private GameObject HowToPlayUI;

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Options()
    {
        OptionsUI.SetActive(true);
        HowToPlayUI.SetActive(false);
        MainMenuUI.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void back()
    {
        OptionsUI.SetActive(false);
        HowToPlayUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }

    public void HowToPlay()
    {
        OptionsUI.SetActive(false);
        HowToPlayUI.SetActive(true);
        MainMenuUI.SetActive(false);
    }

    void Start()
    {
        back();
    }
}
