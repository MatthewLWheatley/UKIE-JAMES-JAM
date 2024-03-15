using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    HealthBar healthBar;
    public float damageAmount = 10.0f;
    //%
    public float currentCorruptionRate = 100.0f;

    public float currentCorruptionState = 0.0f;
    //%
    //public float currentCorruptionSpreadChance = 10.0f;//
    //%
    public float deleteRate;
    //%
    //public float deleteChance;//
    //%
    public float currentDeleteState;
    
    //%
    public float currentAntiVirusDownload = 0.0f;
    //%
    public float currentAntiVirusDownloadRate = 0.0f;
    //%
    public float detectRate;
    //%
    public float antiVirusKillRate = 1.0f;
    //%
    public float currentAntiVirusState = 0.0f;
    
    public float maxAntiVirusState = 100.0f;


    public int money;
    //%
    public float moneyGainRate = 100.0f;

    
    
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

    /*public void UpdateSpreadChance(float value)
    {
        currentCorruptionSpreadChance += value;
    }*/

    public void UpdateDamage(float value)
    {
        damageAmount += value;
    }

    public void UpdateMoney(int value)
    {
        money += value;
    }

    public void UpdateMoneyGainRate(float value)
    {
        moneyGainRate += value;
    }

    public void UpdateAntiVirusDownload(float value)
    {
        currentAntiVirusDownload += value;
    }

    public void UpdateDownloadRate(float value)
    {
        currentAntiVirusDownloadRate += value;
    }

    public void UpdateDetectRate(float value)
    {
        detectRate += value;
    }

    public void UpdateAntiVirusWorkRate(float value)
    {
        antiVirusKillRate += value;
    }

    public void UpdateCurrentAntiVirusState(float value)
    {
        currentAntiVirusState += value;
    }

    public void StartDownload() 
    { 
    
    }

    /*public void UpdateDeleteChance(float value)
    {
        deleteChance += value;
    }*/
}
