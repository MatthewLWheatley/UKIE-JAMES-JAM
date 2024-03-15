using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject[] ObjectHover;

    public void OnPointerEnter(PointerEventData eventData)
    {
        for (int i = 0; i < ObjectHover.Length; i++) 
        {
            ObjectHover[i].SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        for(int i = 0;i < ObjectHover.Length;i++)
        {
            ObjectHover[i].SetActive(false);
        }
    }
}
