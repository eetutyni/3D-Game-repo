using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BerryScript : MonoBehaviour
{
    [SerializeField] private SwapBush bushScript;

    private GameObject player;
    private PlayerHealth plHealth;
    private TextMeshProUGUI collectText;

    private bool collectActive;

    private void Start()
    {
        player = GameObject.Find("Player");
        plHealth = player.GetComponent<PlayerHealth>();
        collectText = GameObject.Find("CollectText").GetComponent<TextMeshProUGUI>();

        collectActive = false;
        collectText.gameObject.SetActive(false);
    }

    public void FixedUpdate()
    {
        // Check if player is in range of bush
        if (Vector3.Distance(transform.position, player.transform.position) < 1f)
        {
            collectText.gameObject.SetActive(true);
            ActivateCollect();
        }
        else 

        /* If collectactive is true and E is pressed
        add health to the player and swap bush to one with no berries */
        if (collectActive && Input.GetKeyDown(KeyCode.E))
        {
            plHealth.AddHealth(2);
            bushScript.Swap();
            DisableCollect();
        }
    }

    //Show collect text
    private void ActivateCollect()
    {
        
        collectActive = true;
    }

    //Hide collect text
    private void DisableCollect()
    {
        collectText.gameObject.SetActive(false);
        collectActive = false;
    }
}
