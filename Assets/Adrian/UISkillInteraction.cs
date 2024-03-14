using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UISkillInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button[] NextSkillsInTree;
    //public 
    private Button Self;
    public GameObject ToolTipObj;
    public TMP_Text CostText;
    public AudioManager audioManager;
    bool SkillActivated;
    public int SkillCost;
    public GameManager gameManager;
    

    private void Start()
    {
        Self = GetComponent<Button>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        SkillActivated = false;
        CostText.text = SkillCost.ToString();
        
    }

    public void ActivateSkill()
    {
        //need to check if currency 
        if (gameManager.money >= SkillCost)
        {
            gameManager.UpdateMoney(-SkillCost);
            Self.interactable = false;
            SkillActivated = true;
            for (int i = 0; i < NextSkillsInTree.Length; i++)
            {
                NextSkillsInTree[i].interactable = true;
            }

            TriggerPerkEffect();
        }
        else
        {
            audioManager.PlaySFX("ErrorSound");
        }
       

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("yo the mouse is over a button babes");
        ToolTipObj.SetActive(true);

        if (!SkillActivated)
        {
            audioManager.PlaySFX("ToolTipOn");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("yo the mouse has left the button :(");
        ToolTipObj.SetActive(false);
        if (!SkillActivated)
        {
            audioManager.PlaySFX("ToolTipOff");
        }
    }

    public virtual void TriggerPerkEffect()
    {

    }
   
}
