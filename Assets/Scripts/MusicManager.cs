using System.Runtime.CompilerServices;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip select;
    public AudioClip decline;
    public AudioClip bomb;
    public AudioClip win;
    public AudioClip musicMenu;
    public AudioClip musicGame;

    private void Start()
    {
        musicSource.clip = musicMenu;
        musicSource.Play();
    }
}

