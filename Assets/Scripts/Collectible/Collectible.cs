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

    /*when collectactive is true and button E is pressed, player gets 2 healthpoints, bush will transform from
    blueberry bush to normal bush and text will dissappear.
    */
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

   
    //if there is object with tag player on the bush, text will show and collectactive will be true
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            ActivateCollect();
            CollectActive = true;

        }

    }

    // when player leaves the bush text deactivates and collectactive = false.
    public void OnTriggerExit(Collider other)
    {
        CollectActive = false;
        DisableCollect();
    }

    //activates text
    private void ActivateCollect()
    {
        collect.gameObject.SetActive(true);

    }

    //deactivates text
    private void DisableCollect()
    {
        collect.gameObject.SetActive(false);
    }
}
