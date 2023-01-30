using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage1 : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {

    }
    public void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
        }
    }
}

