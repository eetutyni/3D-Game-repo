using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage1 : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
        }
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
