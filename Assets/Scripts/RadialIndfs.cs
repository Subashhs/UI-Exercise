using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RadioIndicatorClick : MonoBehaviour
{
    [Header("Radio Timers")]
    [SerializeField] private float indicatorTimer = 1.0f;
    [SerializeField] private float maxIndicatorTimer = 1.0f;

    [Header("UI Indicator")]
    [SerializeField] private Image radioIndicatorUI = null;

    [Header("Key Codes")]
    [SerializeField] private KeyCode selectKey = KeyCode.Mouse0;

    [Header("Unity Event")]
    [SerializeField] private UnityEvent myEvent = null;

    private bool shouldUpdate = false;

    private void Update()
    {
        if (Input.GetKey(selectKey))
        {
            shouldUpdate = false;
            indicatorTimer -= Time.deltaTime;
            radioIndicatorUI.enabled = true;
            radioIndicatorUI.fillAmount = indicatorTimer / maxIndicatorTimer; // Normalized fillAmount

            if (indicatorTimer <= 0)
            {
                indicatorTimer = maxIndicatorTimer;
                radioIndicatorUI.fillAmount = 1;
                radioIndicatorUI.enabled = false;
                myEvent.Invoke();
            }
        }
        else
        {
            if (shouldUpdate)
            {
                indicatorTimer += Time.deltaTime;
                radioIndicatorUI.fillAmount = indicatorTimer / maxIndicatorTimer; // Normalized fillAmount

                if (indicatorTimer >= maxIndicatorTimer)
                {
                    indicatorTimer = maxIndicatorTimer;
                    radioIndicatorUI.fillAmount = 1;
                    radioIndicatorUI.enabled = false;
                    shouldUpdate = false;
                }
            }

            if (Input.GetKeyUp(selectKey))
            {
                shouldUpdate = true;
            }
        }
    }
}
