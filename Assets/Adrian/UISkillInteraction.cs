using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UISkillInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button[] NextSkillsInTree;
    //public 
    private Button Self;
    public GameObject ToolTipObj;

    private void Start()
    {
        Self = GetComponent<Button>();
    }

    public void ActivateSkill()
    {
        //need to check if currency 
        Self.interactable = false;
        for(int i = 0; i < NextSkillsInTree.Length; i++)
        {
            NextSkillsInTree[i].interactable = true;
        }
       

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("yo the mouse is over a button babes");
        ToolTipObj.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("yo the mouse has left the button :(");
        ToolTipObj.SetActive(false);
    }
   
}
