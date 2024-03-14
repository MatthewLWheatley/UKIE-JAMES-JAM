using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    HealthBar healthBar;
    public float damageAmount = 10.0f;
    
    
    private void Start()
    {
        healthBar = GetComponent<HealthBar>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            healthBar.ModifyHealth(damageAmount);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            healthBar.ModifyDetection(damageAmount);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            healthBar.ModifyInteg(damageAmount);
        }
    }
}
