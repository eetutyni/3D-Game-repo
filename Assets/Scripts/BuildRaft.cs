using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildRaft : MonoBehaviour
{
    [SerializeField] private Inventory inventoryScript;

    [SerializeField] private GameObject raft;
    [SerializeField] private GameObject buildText;

    private bool canBuild = false;
    private int partsSet = 0;

    private bool done;

    private void Start()
    {
        buildText.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (done) return;

        if (CamItemChecker.instance.GetItemInView() != null)
        {
            if (CamItemChecker.instance.GetItemInView() == gameObject && inventoryScript.GetPartsInInventory() > 0)
            {
                canBuild = true;
                buildText.SetActive(true);
            }
            else
            {
                canBuild = false;
                buildText.SetActive(false);
            }
        }
        else
        {
            canBuild = false;
            buildText.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && canBuild)
        {
            AddParts(inventoryScript.GetPartsInInventory());
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
