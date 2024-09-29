using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RadialButton : MonoBehaviour
{
    [SerializeField] private float indicatorTimer1 = 1.0f; // Timer for the first radial indicator
    [SerializeField] private float indicatorTimer2 = 1.0f; // Timer for the second radial indicator
    [SerializeField] private float maxIndicatorTimer = 1.0f; // Max timer value

    [SerializeField] private Image radialIndicatorUI1 = null; // First radial indicator
    [SerializeField] private Image radialIndicatorUI2 = null; // Second radial indicator
    [SerializeField] private UnityEvent leftClickEvent = null; // Event for left click
    [SerializeField] private UnityEvent rightClickEvent = null; // Event for right click
    [SerializeField] private ParticleSystem particleSystem1 = null; // Particle system for the first indicator
    [SerializeField] private ParticleSystem particleSystem2 = null; // Particle system for the second indicator

    private bool isActiveIndicator1 = false;
    private bool isActiveIndicator2 = false;

    private void Update()
    {
        // Check for mouse click over the first radial indicator
        if (Input.GetMouseButtonDown(0) && !isActiveIndicator1) // 0 for left mouse button
        {
            if (IsPointerOverUI(radialIndicatorUI1))
            {
                StartRadialIndicator1();
            }
        }

        // Check for mouse click over the second radial indicator
        if (Input.GetMouseButtonDown(1) && !isActiveIndicator2) // 1 for right mouse button
        {
            if (IsPointerOverUI(radialIndicatorUI2))
            {
                StartRadialIndicator2();
            }
        }

        // Update the radial indicators if they're active
        if (isActiveIndicator1)
        {
            UpdateRadialIndicator1();
        }

        if (isActiveIndicator2)
        {
            UpdateRadialIndicator2();
        }
    }

    private bool IsPointerOverUI(Image uiElement)
    {
        if (uiElement == null)
            return false;

        RectTransform rt = uiElement.GetComponent<RectTransform>();
        Vector2 localPoint;
        return RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, Input.mousePosition, null, out localPoint)
               && rt.rect.Contains(localPoint);
    }

    private void StartRadialIndicator1()
    {
        isActiveIndicator1 = true;
        indicatorTimer1 = maxIndicatorTimer; // Reset timer
        radialIndicatorUI1.enabled = true; // Show the first radial indicator
        leftClickEvent.Invoke(); // Trigger the left click event immediately
        particleSystem1.Play(); // Start the particle system
    }

    private void UpdateRadialIndicator1()
    {
        // Decrease the timer
        indicatorTimer1 -= Time.deltaTime;
        radialIndicatorUI1.fillAmount = indicatorTimer1 / maxIndicatorTimer;

        if (indicatorTimer1 <= 0)
        {
            CompleteRadialIndicator1();
        }
    }

    private void CompleteRadialIndicator1()
    {
        radialIndicatorUI1.fillAmount = 1; // Reset fillAmount
        radialIndicatorUI1.enabled = false; // Hide indicator
        isActiveIndicator1 = false; // Mark as inactive
        leftClickEvent.Invoke(); // Trigger the left click event again on completion
        particleSystem1.Stop(); // Stop the particle system
    }

    private void StartRadialIndicator2()
    {
        isActiveIndicator2 = true;
        indicatorTimer2 = maxIndicatorTimer; // Reset timer
        radialIndicatorUI2.enabled = true; // Show the second radial indicator
        rightClickEvent.Invoke(); // Trigger the right click event immediately
        particleSystem2.Play(); // Start the particle system
    }

    private void UpdateRadialIndicator2()
    {
        // Decrease the timer
        indicatorTimer2 -= Time.deltaTime;
        radialIndicatorUI2.fillAmount = indicatorTimer2 / maxIndicatorTimer;

        if (indicatorTimer2 <= 0)
        {
            CompleteRadialIndicator2();
        }
    }

    private void CompleteRadialIndicator2()
    {
        radialIndicatorUI2.fillAmount = 1; // Reset fillAmount
        radialIndicatorUI2.enabled = false; // Hide indicator
        isActiveIndicator2 = false; // Mark as inactive
        rightClickEvent.Invoke(); // Trigger the right click event again on completion
        particleSystem2.Stop(); // Stop the particle system
    }
}
