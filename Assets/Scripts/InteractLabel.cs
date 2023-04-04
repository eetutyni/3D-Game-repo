using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractLabel : MonoBehaviour
{
    public static InteractLabel instance;

    private TextMeshProUGUI label;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    private void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
    }

    private void ShowLabel()
    {
        gameObject.SetActive(true);
    }

    public void SetLabel(string mode)
    {
        switch (mode)
        {
            case "interact":
                label.text = "[E] Interact";
                ShowLabel();
                break;

            case "show":
                label.text = "[E] Show";
                ShowLabel();
                break;

            case "pickup":
                label.text = "[E] Pick up";
                ShowLabel();
                break;
        }
    }

    public void HideLabel()
    {
        gameObject.SetActive(false);
    }
}
