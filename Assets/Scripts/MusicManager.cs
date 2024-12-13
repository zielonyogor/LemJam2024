using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private string currentScene = "Menu";
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip select;
    public AudioClip decline;
    public AudioClip bomb;
    public AudioClip win;

    public AudioClip click;
    public AudioClip musicMenu;
    public AudioClip musicGame;

    public static UnityEvent SceneChanged = new UnityEvent();

    public static MusicManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        if(FindObjectsOfType<AudioForButtons>().Length >= 1)
        {
            FindObjectOfType<AudioForButtons>().Bind();
        }
    }

    void Start()
    {
        Debug.Log(currentScene);
        if(currentScene == "Game")
        {
            //Debug.Log("Game play");
            PlayMusicGame();
        }
        else
        {
            //Debug.Log("Menu play");
            PlayMenuMusic();
        }
        //DontDestroyOnLoad(this.gameObject);



        //SceneManager.sceneLoaded.AddListener(() => { NewScene(); });
        
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("nowa scena");
        NewScene(scene.name);
    }

    public void PlayMenuMusic()
    {
        musicSource.Stop();
        musicSource.clip = musicMenu;
        musicSource.Play();
    }

    public void PlayMusicGame()
    {
        musicSource.Stop();
        musicSource.clip = musicGame;
        musicSource.Play();
    }

    public void PlaySelectSound()
    {
        //SFXSource.clip = select;
        SFXSource.PlayOneShot(select);
    }

    public void PlayClickSound()
    {
        //SFXSource.clip = click;
        //SFXSource.clip = select;
        SFXSource.PlayOneShot(select);
    }

    public void PlayDeclineSound()
    {
        //SFXSource.clip = click;
        //SFXSource.clip = decline;
        SFXSource.PlayOneShot(decline);
    }

    public void PlayBombSound()
    {
        //SFXSource.clip = click;
        //SFXSource.clip = bomb;
        SFXSource.PlayOneShot(bomb);
    }

    public void PlayWinSound()
    {
        //SFXSource.clip = click;
        //SFXSource.clip = win;
        SFXSource.PlayOneShot(win);
    }
    public void NewScene(string sceneName)
    {
        Debug.Log("Scena: "+sceneName);
        if(currentScene == "Menu")
        {
            //Debug.Log("should be Game");
            currentScene = "Game";
            PlayMusicGame();
        }
        else
        {
            //Debug.Log("should be Menu");
            currentScene = "Menu";
            PlayMenuMusic();
        }
        SceneChanged.Invoke();
    }

}
