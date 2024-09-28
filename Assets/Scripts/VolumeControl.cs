using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            Load();  // Load volume if it exists
        }
        else
        {
            PlayerPrefs.SetFloat("musicVolume", 1); // Set default volume if not saved
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value; // Use volumeSlider, not VolumeSlider
        Save();  // Save the new volume value
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");  // Load saved volume
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);  // Save the current slider value
    }
}
