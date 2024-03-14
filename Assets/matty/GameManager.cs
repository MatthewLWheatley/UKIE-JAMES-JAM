using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    HealthBar healthBar;
    public float damageAmount = 10.0f;
    public float currentCorruptionRate = 1.0f;
    public float currentCorruptionSpreadChance;
    public float currentAntiVirusDownload = 0.0f;
    public float downloadRate = 0.0f;

    public int money;

    
    
    private void Start()
    {
        healthBar = GetComponent<HealthBar>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            healthBar.ModifyHealth(damageAmount);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            healthBar.ModifyDetection(damageAmount);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            healthBar.ModifyInteg(damageAmount);
        }
    }

    public void UpdateCorruptionRate(float value)
    {
        currentCorruptionRate += value;
    }

    public void UpdateSpreadChance(float value)
    {
        currentCorruptionSpreadChance += value;
    }

    public void UpdateDamage(float value)
    {
        damageAmount += value;
    }

    public void UpdateMoney(int value)
    {
        money += value;
    }
}
