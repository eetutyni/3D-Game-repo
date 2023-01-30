using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthbar;


    public int maxHealth;
    public int curHealth;
   

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        curHealth -= amount;
        if (curHealth <= 0)
        {
            

        }

        healthbar.UpdateHealth((float)curHealth / (float)maxHealth);



    }
    private void FixedUpdate()

    {
       
    }
}