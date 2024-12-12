using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider VolumeSliderObject;
    [SerializeField] private float StartValue = 0;


    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume",StartValue);
            ChangeVolume();
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
        AudioListener.volume = VolumeSliderObject.value;
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume",VolumeSliderObject.value);
    }

}
