using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsUpdate : MonoBehaviour
{
    public TMP_Text CCRate;
    public TMP_Text CCS;
    public TMP_Text CKR;
    public TMP_Text CKS;
    public TMP_Text CAB;
    public TMP_Text CBM;
    public TMP_Text CADS;
    public TMP_Text CADSpeed;
    public TMP_Text CAKR;
    public TMP_Text CAKS;
    public TMP_Text MAKS;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        
        SetStats();
    }
    public void SetStats()
    {
        CCRate.text = gameManager.currentCorruptionRate.ToString();
        CCS.text = gameManager.currentCorruptionState.ToString();
        CKR.text = gameManager.detectRate.ToString();
        CKS.text = gameManager.currentDeleteState.ToString();
        CAB.text = gameManager.money.ToString();
        CBM.text = gameManager.moneyGainRate.ToString();
        CADS.text = gameManager.currentAntiVirusDownload.ToString();
        CADSpeed.text = gameManager.currentAntiVirusDownloadRate.ToString();
        CAKR.text = gameManager.antiVirusKillRate.ToString();
        CAKS.text = gameManager.currentAntiVirusState.ToString();
        MAKS.text = gameManager.maxAntiVirusState.ToString();
    }
}
