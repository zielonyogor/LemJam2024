
using System.Runtime.CompilerServices;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private bool DontDestroy = true;
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

    private bool loaded = false;

    /*void Awake()
    {
        if(!DontDestroy)
        {
            return;
        }

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        
    }*/

    void Start()
    {
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
        //GameObject AudioButtons = GameObject.Find("ButtonSFXHandler");
        
        //AudioButtons.GetComponent<AudioForButtons>.Bind();
        //if(FindObjectsOfType<AudioForButtons>().Length >= 1)
        //{
        //    Debug.Log(AudioButtons);
        //}
        //DontDestroyOnLoad(this.gameObject);



        //SceneManager.sceneLoaded.AddListener(() => { NewScene(); });
        
    }

    /*void Update()
    {
        if(!loaded)
        {
            GameObject AudioButtons = GameObject.Find("ButtonSFXHandler");
            if (AudioButtons != null)
            {
                loaded = true;
                Debug.Log(AudioButtons);
                AudioButtons.GetComponent<AudioForButtons>().Bind(AudioButtons);
                //AudioButtons.GetComponent<AudioForButtons>.Bind();
            }
        }
    }*/

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
        loaded = false;
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



