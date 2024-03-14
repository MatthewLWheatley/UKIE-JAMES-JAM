//using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class VirtualPet : MonoBehaviour
{
    public Vector3 movementAreaSize; // Size of the movement area
    public float movementSpeed = 1f; // Speed of movement
    
    public float minDelay = 1f;
    public float maxDelay = 5f;

    private Vector3 targetPosition; // Random target position within the movement area

    void Start()
    {
        StartCoroutine(MoveDelay());
    }

    void Update()
    {
        MoveTowardsTarget();
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
    }

   /* void CheckReachedDestination()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }
    }*/

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
                    yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
                    SetRandomTargetPosition();
                    break;

                case 1:
                    Debug.Log("Speech");
                    yield return new WaitForSeconds(5);
                    SetRandomTargetPosition();
                    break;

                case 2:
                    yield return new WaitForSeconds(5);
                    SetRandomTargetPosition();
                    break;
            }
        }
    }
}

