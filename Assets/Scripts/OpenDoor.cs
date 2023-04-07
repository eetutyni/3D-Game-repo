using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public bool canOpen = false;
    public bool doorOpen = false;
    private bool doorUnlocked = false;

    private GameObject camera;

    private void Start()
    {
        camera = GameObject.Find("Main Camera");
    }

    private void FixedUpdate()
    {
        GameObject viewItem = CamItemChecker.instance.GetItemInView();
        if ( viewItem != null && viewItem.tag == "door") canOpen = true;
        else canOpen = false;

        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 3f))
        {
            if (hit.collider.gameObject.layer == 9) canOpen = true;
            else canOpen = false;
        }
        else canOpen = false;

        if (Input.GetKeyDown(KeyCode.E) && canOpen && doorUnlocked)
        {
            if (doorOpen) { anim.Play("CloseDoors"); doorOpen = false; }
            else { anim.Play("OpenDoors"); doorOpen = true; }
        }
    }

    public void UnlockDoor()
    {
        doorUnlocked = true;
    }

    public bool GetDoorUnlocked()
    {
        return doorUnlocked;
    }
}
