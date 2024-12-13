using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] Button retryButton;
    [SerializeField] Button mainMenuButton;

    GameObject panel;
    void Start()
    {
        panel = transform.GetChild(0).gameObject;
        panel.SetActive(false);

        retryButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("SampleScene");
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainMenu");
        });

        timer.Timeout.AddListener(() =>
        {
            winText.text = $"Player {ResourceManager.instance.GetPlayerWin()} wins";
            panel.SetActive(true);
        });
    }
}
