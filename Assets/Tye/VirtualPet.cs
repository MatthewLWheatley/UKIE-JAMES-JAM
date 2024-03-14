//using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        // CheckReachedDestination();
    }

    void SetRandomTargetPosition()
    {
        float randomX = Random.Range(-movementAreaSize.x / 2f, movementAreaSize.x / 2f);
        float randomY = Random.Range(-movementAreaSize.y / 2f, movementAreaSize.y / 2f);
        targetPosition = new Vector3(randomX, randomY, transform.position.z);
    }

    void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y , ZStart);
    }

   /* void CheckReachedDestination()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }
    }*/

    private void UpdateMessagePosition()
    {
        if (petTransform != null)
        {
            Vector3 worldPosition = petTransform.position + textOffset;
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
            messageRectTransform.position = screenPosition;
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
            int randomChance = Random.Range(0, 3);

            switch (randomChance)
            {
                case 0:
                    UpdateMessageText("");
                    yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
                    SetRandomTargetPosition();
                    break;

                case 1:
                    UpdateMessageText("Balls");
                    yield return new WaitForSeconds(5);
                    SetRandomTargetPosition();
                    UpdateMessageText("");
                    break;

                case 2:
                    UpdateMessageText("I know where you sleep at night...");
                    yield return new WaitForSeconds(5);
                    SetRandomTargetPosition();
                    UpdateMessageText("");
                    break;
            }
        }
    }
}

