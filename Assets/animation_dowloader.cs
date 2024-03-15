using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animation_dowloader : MonoBehaviour
{
    public Image displayImage; // Assign in the inspector, the Image component where you want to display the pictures
    public List<Sprite> images = new List<Sprite>(); // Assign your images in the inspector
    public float flipInterval = 1f; // Time in seconds between each image flip

    private int currentIndex = 0;
    private bool isFlipping = false;

    void Start()
    {
        if (images.Count > 0)
        {
            StartFlipping();
        }
    }

    void StartFlipping()
    {
        if (!isFlipping)
        {
            StartCoroutine(FlipThroughImages());
            isFlipping = true;
        }
    }

    IEnumerator FlipThroughImages()
    {
        while (true)
        {
            displayImage.sprite = images[currentIndex];
            currentIndex = (currentIndex + 1) % images.Count;
            yield return new WaitForSeconds(flipInterval);
        }
    }
}
