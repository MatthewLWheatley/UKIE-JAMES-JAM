//using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Animations;

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

    private Vector3 targetPosition; // Random target position within the movement area
    private RectTransform messageRectTransform;
    public Animator animator;

    void Start()
    {       
        ZStart = transform.position.z;
        messageRectTransform = messageText.GetComponent<RectTransform>();

        StartCoroutine(MoveDelay());
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

            messageRectTransform.position = new Vector3(screenPosition.x,screenPosition.y,textOffset.z);

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

    // Draw the movement area in the scene for visualization purposes
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(movementAreaSize.x, movementAreaSize.y, movementAreaSize.z));
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
                    //Debug.Log("Nothing");
                    yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
                    animator.SetBool("isWalking?", false);
                    animator.SetBool("isTalking?", false);
                    SetRandomTargetPosition();
                    break;

                case 1:
                    animator.SetBool("isTalking?", true);
                    UpdateMessageText("Balls");
                    //Debug.Log("Balls");
                    yield return new WaitForSeconds(5);
                    animator.SetBool("isWalking?", false);
                    //SetRandomTargetPosition();
                    UpdateMessageText("");
                    break;

                case 2:
                    animator.SetBool("isTalking?", true);
                    //Debug.Log("I know");
                    UpdateMessageText("I know where you sleep at night...");
                    yield return new WaitForSeconds(5);
                    animator.SetBool("isWalking?", false);
                    //SetRandomTargetPosition();
                    UpdateMessageText("");
                    break;

                case 3:
                    UpdateMessageText("");
                    //Debug.Log("Nothing 2");
                    yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
                    animator.SetBool("isWalking?", false);
                    animator.SetBool("isTalking?", false);
                    //SetRandomTargetPosition();
                    break;

                case 4:
                    UpdateMessageText("Cool Bird fact! I see you.");
                    //Debug.Log("Oh yeah");
                    yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
                    animator.SetBool("isWalking?", false);
                    animator.SetBool("isTalking?", false);
                    //SetRandomTargetPosition();
                    break;
            }
        }
    }
}

