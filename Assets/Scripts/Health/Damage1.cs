using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage1 : MonoBehaviour
{
    private int playerDamage = 1;
    [SerializeField] private HealthController _healthController;
    HealthController healthController;





    public void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            Damage();
        }


    }
    public void Damage()
    {

        _healthController.playerHealth = _healthController.playerHealth - playerDamage;
        _healthController.UpdateHealth();



    }

}