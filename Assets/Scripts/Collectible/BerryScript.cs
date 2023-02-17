using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BerryScript : MonoBehaviour
{
    public PlayerHealth plHealth;

    [SerializeField] private SwapBush bushScript;
    [SerializeField] TextMeshProUGUI collect;

    private bool collectActive;

    private void Start()
    {
        collectActive = false;
    }

    public void FixedUpdate()
    {
        /* If collectactive is true and E is pressed
        add health to the player and swap bush to one with no berries */
        if (collectActive && Input.GetKeyDown(KeyCode.E))
        {
            plHealth.AddHealth(2);
            bushScript.Swap();
            DisableCollect();
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        //If player enters bush trigger ActivateCollect is called
        if (col.CompareTag("Player"))
        {
            ActivateCollect();
        }
    }

    public void OnTriggerExit(Collider col)
    {
        //If player exits bush trigger DisableCollect is called
        if (col.CompareTag("Player"))
        {
            DisableCollect();
        }
    }

    //Show collect text
    private void ActivateCollect()
    {
        collect.gameObject.SetActive(true);
        collectActive = true;
    }

    //Hide collect text
    private void DisableCollect()
    {
        collect.gameObject.SetActive(false);
        collectActive = false;
    }
}
