using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public PlayerHealth plHealth;

    [SerializeField] private SwapBush bushScript;

    private bool CollectActive;

    private void Start()
    {
        CollectActive = false;
    }

    [SerializeField] TextMeshProUGUI collect;
    public void FixedUpdate()
    {
        if (CollectActive && Input.GetKeyDown(KeyCode.E))
        {
            plHealth.AddHealth(2);
            bushScript.Swap();
            CollectActive = false;
            DisableCollect();
        }
       
    }

   
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            ActivateCollect();
            CollectActive = true;

        }

    }

    public void OnTriggerExit(Collider other)
    {
        CollectActive = false;
        DisableCollect();
    }


    private void ActivateCollect()
    {
        collect.gameObject.SetActive(true);

    }

    private void DisableCollect()
    {
        collect.gameObject.SetActive(false);
    }
}
