//using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEditor.Animations;

public class VirtualPet : MonoBehaviour
{
    public Vector3 movementAreaSize; // Size of the movement area
    public float movementSpeed = 1f; // Speed of movement
    
    public float minDelay = 1f;
    public float maxDelay = 5f;

    public float ZStart = 0f;

    public Transform petTransform;
    public Vector3 textOffset;
    
    public TMP_Text messageText;
    public GameObject MessagePosRef;

    private Vector3 targetPosition; // Random target position within the movement area
    private RectTransform messageRectTransform;
    public Animator animator;
    private GameManager gameManager;
    public float timeBetweenActions;

    public string[] GoodLines;
    public string[] WhatLines;
    public string[] CorruptedLines;
    public string[] AhhhhhLines;

    void Start()
    {       
        ZStart = transform.position.z;
        messageRectTransform = messageText.GetComponent<RectTransform>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        StartCoroutine(AiStateMachine());
        //StartCoroutine(MoveDelay());
    }

    void Update()
    {
        MoveTowardsTarget();
        UpdateMessagePosition();
        CheckReachedDestination();
    }

    void SetRandomTargetPosition()
    {
        float randomX = Random.Range(-movementAreaSize.x / 2f, movementAreaSize.x / 2f);
        float randomY = Random.Range(-movementAreaSize.y / 2f, movementAreaSize.y / 2f);
        targetPosition = new Vector3(randomX, randomY, transform.position.z);
    }

    void MoveTowardsTarget()
    {
        animator.SetBool("isWalking?", true);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
        float temp = targetPosition.x - transform.position.x;
        if (temp >= 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX= false;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y , ZStart);
    }

    void CheckReachedDestination()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            animator.SetBool("isWalking?", false);
        }
    }

    private void UpdateMessagePosition()
    {
        if (petTransform != null)
        {
            Vector3 worldPosition = petTransform.position + textOffset;
            Vector2 screenPosition = new Vector2(worldPosition.x, worldPosition.y);//Camera.main.WorldToScreenPoint(worldPosition);
            messageRectTransform.position = screenPosition;

            MessagePosRef.transform.position = new Vector3(screenPosition.x, screenPosition.y, textOffset.z);
            //messageRectTransform.position = new Vector3(screenPosition.x,screenPosition.y,textOffset.z);

            messageRectTransform.SetAsLastSibling();
        }
        else
        { 
            messageText.gameObject.SetActive(false);
        }
    }

    private void UpdateMessageText(string message)
    {
        messageText.text = message;
    }


    private void HideSpeechBubble()
    {
        var tempColour = MessagePosRef.GetComponent<Image>().color;
        tempColour.a = 0;

        MessagePosRef.GetComponent<Image>().color = tempColour;
    }

    private void ShowSpeechBubble()
    {
        var tempColour = MessagePosRef.GetComponent<Image>().color;
        tempColour.a = 1;

        MessagePosRef.GetComponent<Image>().color = tempColour;
    }
    // Draw the movement area in the scene for visualization purposes
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(movementAreaSize.x, movementAreaSize.y, movementAreaSize.z));
    }

    IEnumerator AiStateMachine()
    {
        int randChoice = Random.Range(0, 3);
        Debug.Log("randChoice was: " + randChoice);
        switch(randChoice)
        {
            //move somewhere
            case 0:
                UpdateMessageText("");
                HideSpeechBubble();
                animator.SetBool("isWalking?", false);
                animator.SetBool("isTalking?", false);
                SetRandomTargetPosition();
            break;
            //chat some shit
            case 1:
                animator.SetBool("isTalking?", true);
                ShowSpeechBubble();
                chooseRandomLines();
                break;
            //be an idle idol
            case 2:
                UpdateMessageText("");
                HideSpeechBubble();
                targetPosition = transform.position;
            break;

        }

        yield return new WaitForSeconds(timeBetweenActions);
        StartCoroutine(AiStateMachine());
    }

    private void chooseRandomLines()
    {
        float temp = gameManager.CorruptionState;
        int randVoiceLine;
        if(temp < 25)
        {
            //goodlines
            randVoiceLine = Random.Range(0, GoodLines.Length - 1);
            UpdateMessageText(GoodLines[randVoiceLine]);
        }
        else if(temp >= 25 && temp < 50)
        {
            //what lines
            randVoiceLine = Random.Range(0, WhatLines.Length - 1);
            UpdateMessageText(WhatLines[randVoiceLine]);
        }
        else if(temp >= 50 && temp < 75)
        {
            //corrupted lines
            randVoiceLine = Random.Range(0, CorruptedLines.Length - 1);
            UpdateMessageText(CorruptedLines[randVoiceLine]);
        }
        else
        {
            //ahhhhhhhhhh
            randVoiceLine = Random.Range(0, AhhhhhLines.Length - 1);
            UpdateMessageText(AhhhhhLines[randVoiceLine]);
        }
       
    }

    IEnumerator MoveDelay()
    {

        while (true) 
        {
            int randomChance = Random.Range(0, 5);

            switch (randomChance)
            {
                case 0:
                    UpdateMessageText("");
                    Debug.Log("Nothing");
                    yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
                    animator.SetBool("isWalking?", false);
                    animator.SetBool("isTalking?", false);
                    SetRandomTargetPosition();
                    break;

                case 1:
                    animator.SetBool("isTalking?", true);
                    UpdateMessageText("Balls");
                    Debug.Log("Balls");
                    yield return new WaitForSeconds(5);
                    animator.SetBool("isWalking?", false);
                    //SetRandomTargetPosition();
                    UpdateMessageText("");
                    break;

                case 2:
                    animator.SetBool("isTalking?", true);
                    Debug.Log("I know");
                    UpdateMessageText("I know where you sleep at night...");
                    yield return new WaitForSeconds(5);
                    animator.SetBool("isWalking?", false);
                    //SetRandomTargetPosition();
                    UpdateMessageText("");
                    break;

                case 3:
                    UpdateMessageText("");
                    Debug.Log("Nothing 2");
                    yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
                    animator.SetBool("isWalking?", false);
                    animator.SetBool("isTalking?", false);
                    //SetRandomTargetPosition();
                    break;

                case 4:
                    UpdateMessageText("Cool Bird fact! I see you.");
                    Debug.Log("Oh yeah");
                    yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
                    animator.SetBool("isWalking?", false);
                    animator.SetBool("isTalking?", false);
                    //SetRandomTargetPosition();
                    break;

                case 5:
                    UpdateMessageText("The Human body contains 1.3 gallons of blood! Thats almost enough to satiate me!");
                    Debug.Log("Oh");
                    yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
                    animator.SetBool("isWalking?", false);
                    animator.SetBool("isTalking?", false);
                    SetRandomTargetPosition();
                    break;
            }
        }
    }
}

