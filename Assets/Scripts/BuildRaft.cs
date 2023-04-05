using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildRaft : MonoBehaviour
{
    [SerializeField] private Inventory inventoryScript;
    [SerializeField] private InteractLabel labelScript;
    [SerializeField] private GameObject raft;

    private bool canBuild = false;
    private int partsSet = 0;

    private bool done = false;

    private void FixedUpdate()
    {
        if (done) return;

        if (CamItemChecker.instance.GetItemInView() != null)
        {
            if (CamItemChecker.instance.GetItemInView() == gameObject && inventoryScript.GetPartsInInventory().Count > 0)
            {
                canBuild = true;
            }
            else
            {
                canBuild = false;
            }
        }
        else
        {
            canBuild = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && canBuild)
        {
            AddParts(inventoryScript.GetPartsInInventory().Count);
        }

        if (partsSet >= 5)
        {
            SpawnRaft();
            done = true;
        }
    }

    public void AddParts(int partCount)
    {
        partsSet += partCount;
    }

    private void SpawnRaft()
    {
        raft.SetActive(true);
    }
}
