using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    HealthBar healthBar;
    public float damageAmount = 10.0f;
    //%
    public float CorruptionRate = 0.0f;

    public float CorruptionState = 0.0f;
    //%
    //public float CorruptionSpreadChance = 10.0f;//
    //%
    public float deleteRate;
    //%
    //public float deleteChance;//
    //%
    public float DeleteState;
    
    //%
    public float AntiVirusDownload = 0.0f;
    //%
    public float AntiVirusDownloadRate = 0.0f;
    //%
    public float detectRate;
    //%
    public float antiVirusKillRate = 1.0f;
    //%
    public float AntiVirusState = 0.0f;
    
    public float maxAntiVirusState = 100.0f;


    public float money;
    public float baseMoneyGain = 10.0f;
    //%
    public float moneyGainRate = 100.0f;

    public GameObject DownloadObject;
    public GameObject CurupttertionObject;
    public GameObject deleleObject;
    public GameObject BitCounter;

    private void Start()
    {
        healthBar = GetComponent<HealthBar>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartDownload();
        }
        UpdateDownload();
        updateCururproru();
        updateDelelete();
        updateBits();
    }

    public void UpdateCorruptionRate(float value)
    {
        CorruptionRate += value;
    }

    /*public void UpdateSpreadChance(float value)
    {
        CorruptionSpreadChance += value;
    }*/

    public void UpdateDamage(float value)
    {
        damageAmount += value;
    }

    public void UpdateDeleteRate(float value)
    {
        deleteRate += value;
    }

    public void UpdateMoney(int value)
    {
        money += value;
    }

    public void UpdateMoney()
    {
        money += baseMoneyGain * moneyGainRate / 100.0f;
    }

    public void UpdateMoneyGainRate(float value)
    {
        moneyGainRate += value;
    }

    public void UpdateAntiVirusDownload(float value)
    {
        AntiVirusDownload += value;
    }

    public void UpdateDownloadRate(float value)
    {
        AntiVirusDownloadRate += value;
    }

    public void UpdateDetectRate(float value)
    {
        detectRate += value;
    }

    public void UpdateAntiVirusWorkRate(float value)
    {
        antiVirusKillRate += value;
    }

    public void UpdateAntiVirusState(float value)
    {
        AntiVirusState += value;
    }

    public void StartDownload() 
    { 
        DownloadObject.SetActive(true);
    }

    public void UpdateDownload() 
    {
        if (DownloadObject.activeSelf)
        {
            DownloadObject.gameObject.transform.GetChild(0).GetComponent<Slider>().value = AntiVirusDownload;
            AntiVirusDownload += AntiVirusDownloadRate;
        }
    }

    public void updateCururproru() 
    {
        if (CurupttertionObject.activeSelf)
        {
            CurupttertionObject.gameObject.transform.GetChild(0).GetComponent<Slider>().value = CorruptionState;
        }
        CorruptionState += CorruptionRate*Time.deltaTime;
    }

    public void updateDelelete()
    {
        if (deleleObject.activeSelf)
        {
            deleleObject.gameObject.transform.GetChild(0).GetComponent<Slider>().value = DeleteState;
        }

        DeleteState += deleteRate * Time.deltaTime;
    }

    public void updateBits()
    {
        BitCounter.GetComponent<TMP_Text>().text = $"{money}";
    }

    /*public void UpdateDeleteChance(float value)
    {
        deleteChance += value;
    }*/
}
