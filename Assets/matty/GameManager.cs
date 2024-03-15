using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    public float SpreadRate = 4.0f;


    public float money;
    public float baseMoneyGain = 16.0f;
    //%
    public float moneyGainRate = 100.0f;

    public GameObject DownloadObject;
    public GameObject AntiVirusProgressBar;
    public GameObject CurupttertionObject;
    public GameObject deleleObject;
    public GameObject BitCounter;
    public GameObject FileManager;

    private float PercentOfVirusToStartDownload;

    private void Awake()
    {
        difficultyTransfer diffSettings = GameObject.FindAnyObjectByType<difficultyTransfer>();
        if (diffSettings != null)
        {
            SetGameDifficulty(diffSettings.Difficulty);
        }
        else
        {
            SetGameDifficulty(1);
        }
    }

    private void Start()
    {
        healthBar = GetComponent<HealthBar>();
        StartCoroutine(StartDeletion());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartDownload();
        }
        UpdateDownload();
        UpdateAntiVirusProgress();
        updateCururproru();
        updateDelelete();
        updateBits();
        CheckIfDownloadNeedsToStart();
        CheckDeletionRate();
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
        money += baseMoneyGain * (moneyGainRate / 100.0f);
        Debug.Log("moneys");
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
    public void UpdateBaseAmountOfMoney(int value)
    {
        baseMoneyGain += value;
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
            //AntiVirusDownload += AntiVirusDownloadRate;
        }
    }

    public void UpdateAntiVirusProgress()
    {
        if (AntiVirusProgressBar.activeSelf)
        {
            AntiVirusProgressBar.gameObject.transform.GetChild(0).GetComponent<Slider>().value = AntiVirusState;
        }
    }

    public IEnumerator StartAntiDownload()
    {
        
        yield return new WaitForSeconds(5f);
        AntiVirusDownload += AntiVirusDownloadRate;
        if (AntiVirusDownload >= 100)
        {
            DownloadObject.SetActive(false);
            StartAntiVirus();
        }
        else
        {
            StartCoroutine(StartAntiDownload());
        }
    }

    public IEnumerator StartDeletion()
    {
        yield return new WaitForSeconds(1);
        DeleteState += deleteRate;
        StartCoroutine(StartDeletion());
    }

    public IEnumerator StartAntiVirusProcess()
    {
        yield return new WaitForSeconds(5f);
        AntiVirusState += antiVirusKillRate;
        if(AntiVirusState >= 100)
        {
            Debug.Log("YOU LOSe");
            LoseTheGame();
            //losE the game
        }
    }

    public void updateCururproru() 
    {
        if (CurupttertionObject.activeSelf)
        {
            CurupttertionObject.gameObject.transform.GetChild(0).GetComponent<Slider>().value = CorruptionState;
        }
        CorruptionState = FileManager.GetComponent<DrawWindow>().corruptCounter;
    }

    public void updateDelelete()
    {
        if (deleleObject.activeSelf)
        {
            deleleObject.gameObject.transform.GetChild(0).GetComponent<Slider>().value = DeleteState;
        }
        DeleteState = FileManager.GetComponent<DrawWindow>().deletionCounter;
        //DeleteState += deleteRate * Time.deltaTime;
    }

    public void updateBits()
    {
        BitCounter.GetComponent<TMP_Text>().text = $"{money}";
    }

    private void CheckIfDownloadNeedsToStart()
    {
        if (CorruptionState >=  PercentOfVirusToStartDownload && DownloadObject.active == false)
        {
            DownloadObject.SetActive(true);
            StartCoroutine(StartAntiDownload());
        }
    }

    private void CheckDeletionRate()
    {
       if(DeleteState >= 80)
        {
            //win the game
            WinTheGame();
        }
    }

    

    private void StartAntiVirus()
    {
        AntiVirusProgressBar.SetActive(true);
        StartCoroutine(StartAntiVirusProcess());
    }

    public void SetGameDifficulty(int Diff)
    {
        switch(Diff)
        {
            
            case 1:
                AntiVirusDownloadRate = 1.5f;
                antiVirusKillRate = 1.0f;
                Debug.Log("the game difficulty is easy");
                PercentOfVirusToStartDownload = 75.0f;
                break; 
            
            case 2:
                AntiVirusDownloadRate = 3.0f;
                antiVirusKillRate = 2.0f;
                Debug.Log("the game difficulty is normal");
                PercentOfVirusToStartDownload = 50.0f;
                break; 
            
            case 3:
                AntiVirusDownloadRate = 7.0f;
                antiVirusKillRate = 4.0f;
                Debug.Log("the game difficulty is hard");
                PercentOfVirusToStartDownload = 25.0f;
                break;
        }
    }

    public void LoseTheGame()
    {
        //load game over scene
        SceneManager.LoadScene("LoseScreen");
    }

    public void WinTheGame()
    {
        SceneManager.LoadScene("WinScreen");
    }
    /*public void UpdateDeleteChance(float value)
    {
        deleteChance += value;
    }*/
}
