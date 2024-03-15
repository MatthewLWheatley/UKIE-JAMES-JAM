using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class MenuInter : MonoBehaviour
{
    //public Slider
    GameManager gameManager;
    TMP_Text bitValue;
    public AudioMixer audioMixer;
    public AudioMixerGroup Master;
    public AudioMixerGroup SFX;
    public AudioMixerGroup Music;

    float MasterVol;
    float SFXVol;
    float MusicVol;

    public Slider MasterSlider;
    public Slider SFXSlider;
    public Slider MusicSlider;


    private void Start()
    {
        gameManager = GetComponent<GameManager>();  
        //bitValue.text = gameManager.money.ToString();
        audioMixer.GetFloat("MasterVol", out MasterVol);
        audioMixer.GetFloat("SFXVol", out SFXVol);
        audioMixer.GetFloat("MusicVol", out MusicVol);
        MasterSlider.value = MasterVol;
        MusicSlider.value = MusicVol;   
        SFXSlider.value = SFXVol;



    }

    public void OnMasterChange(float value)
    {
        audioMixer.SetFloat("MasterVol", value);
        //Master.value = value;
    }

    public void OnSFXChange(float value)
    {
        audioMixer.SetFloat("SFXVol", value);
        //SFXSlider.value = value;
    }

    public void OnMusicChane(float value)
    {
        audioMixer.SetFloat("MusicVol", value);
        //MusicSlider.value = value;
    }


}
