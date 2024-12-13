using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private string startingMusic = "Menu";
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip select;
    public AudioClip decline;
    public AudioClip bomb;
    public AudioClip win;
    public AudioClip musicMenu;
    public AudioClip musicGame;

    void Start()
    {
        if(startingMusic == "Game")
        {
            PlayMusicGame();
        }
        else
        {
            PlayMenuMusic();
        }
        
        
    }

    void PlayMenuMusic()
    {
        musicSource.clip = musicMenu;
        musicSource.Play();
    }

    void PlayMusicGame()
    {
        musicSource.clip = musicGame;
        musicSource.Play();
    }

    void PlaySelectSound()
    {

    }

}
