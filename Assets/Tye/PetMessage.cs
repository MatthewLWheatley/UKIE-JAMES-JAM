using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMessage : MonoBehaviour
{
    public Transform petTransform;
    public Vector3 offset;
    private RectTransform rectTransform;


    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (petTransform != null) 
        { 
            Vector3 worldPosition = petTransform.position + offset;
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
            rectTransform.position = screenPosition;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void SetPetTransform(Transform pet)
    {
        petTransform = pet;
    }
}
