using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuFunc : MonoBehaviour
{
    public void flipFlop()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
