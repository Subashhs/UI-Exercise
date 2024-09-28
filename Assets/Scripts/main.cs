

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;    // Reference to the slider

    private bool isSliderVisible = false;           // State to track if the slider is visible

    public void OnPlayButton()
    {
        // Load the scene with index 1
        SceneManager.LoadScene(1);
    }

    public void OnOptionButton()
    {
        if (volumeSlider == null)
        {
            Debug.LogError("volumeSlider is not assigned in the Inspector.");
            return;
        }

        // Toggle the slider visibility when the Option button is clicked
        isSliderVisible = !isSliderVisible;
        volumeSlider.gameObject.SetActive(isSliderVisible); // Show or hide the slider
    }

    public void OnVolumeChange()
    {
        AudioListener.volume = volumeSlider.value;
    }

}
