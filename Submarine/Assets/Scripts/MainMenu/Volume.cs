using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider VolumeSlider;
    public float VolumeLevel;
    void Start()
    {
        if(PlayerPrefs.HasKey("soundVolume"))
            LoadVolume();
        else
        {
            PlayerPrefs.SetFloat("soundVolume", 1);
            LoadVolume();
        }
    }

    public void SetVolume()
    {
        AudioListener.volume = VolumeSlider.value;
        VolumeLevel = VolumeSlider.value;
        SaveVolume();  
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("soundVolume", VolumeSlider.value);
    }

    public void LoadVolume()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }
}


