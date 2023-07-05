using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Add Gauge class
    [SerializeField] private Gauge health;
    // Add Image to be filled
    [SerializeField] private Image fillImage;

    // Subscribe a function that would call the Action on the Gauge Class onEnable
    private void OnEnable() => health.OnChange += updateGauge;
    // Unsubscribe a Action on the Gauge Class onDisable
    private void OnDisable() => health.OnChange -= updateGauge;

    // Create a function that would update the healthbar
    private void updateGauge() => fillImage.fillAmount = health.Ratio;

}
