using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RRadioIndicatorClick : MonoBehaviour
{
    [Header("RRadio Timers")]
    [SerializeField] private float indicatorTimer = 1.0f;
    [SerializeField] private float maxIndicatorTimer = 1.0f;

    [Header("UI Indicator")]
    [SerializeField] private Image rradioIndicatorUI = null;

    [Header("Key Codes")]
    [SerializeField] private KeyCode selectKey = KeyCode.Mouse1;

    [Header("Unity Event")]
    [SerializeField] private UnityEvent myEvent = null;

    private bool shouldUpdate = false;

    private void Update()
    {
        if (Input.GetKey(selectKey))
        {
            shouldUpdate = false;
            indicatorTimer -= Time.deltaTime;
            rradioIndicatorUI.enabled = true;
            rradioIndicatorUI.fillAmount = indicatorTimer / maxIndicatorTimer; // Normalized fillAmount

            if (indicatorTimer <= 0)
            {
                indicatorTimer = maxIndicatorTimer;
                rradioIndicatorUI.fillAmount = 1;
                rradioIndicatorUI.enabled = false;
                myEvent.Invoke();
            }
        }
        else
        {
            if (shouldUpdate)
            {
                indicatorTimer += Time.deltaTime;
                rradioIndicatorUI.fillAmount = indicatorTimer / maxIndicatorTimer; // Normalized fillAmount

                if (indicatorTimer >= maxIndicatorTimer)
                {
                    indicatorTimer = maxIndicatorTimer;
                    rradioIndicatorUI.fillAmount = 1;
                    rradioIndicatorUI.enabled = false;
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