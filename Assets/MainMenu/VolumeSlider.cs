using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider VolumeSliderObject;


    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume",1);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ChangeVolume()
    {
        AudioListener.volume = VolumeSliderObject.value;
        Save();
    }

    private void Load()
    {
        VolumeSliderObject.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume",VolumeSliderObject.value);
    }
}
