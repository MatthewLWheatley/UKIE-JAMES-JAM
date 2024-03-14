using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; // Assign this in the inspector
    public float maxHealth = 100f;
    private float currentHealth;

    public Slider detectionSlider; // Assign this in the inspector
    public float maxDetection = 100f;
    private float currentDetection;

    public Slider integSlider; // Assign this in the inspector
    public float maxInteg = 100f;
    private float currentInteg;


    void Start()
    {
        currentHealth = maxHealth; 
        currentDetection = maxDetection; 
        currentInteg = maxInteg; 
        UpdateHealthSlider(); 
        UpdateDetectionSlider(); 
        UpdateIntegSlider(); 
    }

    public void ModifyHealth(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Prevent health from going below 0 or above max
        UpdateHealthSlider();
    }

    public void ModifyDetection(float damage)
    {
        currentDetection -= damage;
        currentDetection = Mathf.Clamp(currentDetection, 0, maxDetection); // Prevent health from going below 0 or above max
        UpdateDetectionSlider();
    }

    public void ModifyInteg(float damage)
    {
        currentInteg -= damage;
        currentInteg = Mathf.Clamp(currentInteg, 0, maxInteg); // Prevent health from going below 0 or above max
        UpdateIntegSlider();
    }

    void UpdateHealthSlider()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth / maxHealth; // Update the slider's value
        }
    }

    void UpdateDetectionSlider()
    {
        if (detectionSlider != null)
        {
            detectionSlider.value = currentDetection / maxDetection; // Update the slider's value
        }
    }

    void UpdateIntegSlider()
    {
        if (integSlider != null)
        {
            integSlider.value = currentInteg/ maxInteg; // Update the slider's value
        }
    }
}
