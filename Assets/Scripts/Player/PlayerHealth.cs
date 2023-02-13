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


    //damage
    public void TakeDamage(int amount)
    {
        curHealth -= amount;
        if (curHealth <= 0)
        {
            curHealth= 0;

        }

        healthbar.UpdateHealth((float)curHealth / (float)maxHealth);



    }

    public void AddHealth(int amountt)
    {
        curHealth += amountt;
        healthbar.UpdateHealth((float)curHealth / (float)maxHealth);

        if (curHealth >= 10)
        {
            curHealth = 10;

        }
    }

     
}