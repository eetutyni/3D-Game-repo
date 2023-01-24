using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthbar;
    private Transform playerTransform;

    public int maxHealth;
    public int curHealth;
   

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        playerTransform = GetComponent<Transform>();

    }

    public void TakeDamage(int amount)
    {
        curHealth -= amount;
        if (curHealth <= 0)
        {
            

        }

        healthbar.updateHealth((float)curHealth / (float)maxHealth);



    }
    private void FixedUpdate()

    {
        if (playerTransform.position.y < -10)
        {
            
        }
    }
}