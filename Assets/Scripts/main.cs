using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    [SerializeField] private Slider Slider;    // Reference to the slider

    private void Start()
    {
        // Initially hide the slider when the game starts
        if (Slider != null)
        {
            Slider.gameObject.SetActive(false);    // Make sure the slider is hidden initially
        }
    }

    public void OnPlayButton()
    {
        // Load the scene with index 1
        SceneManager.LoadScene(1);
    }

    public void OnOptionButton()
    {
        if (Slider != null)
        {
            // Make the slider visible when the Option button is clicked
            Slider.gameObject.SetActive(true);
        }
    }
}
