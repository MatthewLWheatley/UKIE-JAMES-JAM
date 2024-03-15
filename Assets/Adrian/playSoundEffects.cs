using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundEffects : MonoBehaviour
{
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindAnyObjectByType<AudioManager>();
    }

    public void playSound()
    {
        audioManager.PlaySFX("ErrorSound");
    }

}
