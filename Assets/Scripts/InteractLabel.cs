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

    public void HideLabel()
    {
        gameObject.SetActive(false);
    }

    public void SetLabel(string mode)
    {
        switch (mode)
        {
            case "open":
                label.text = "[E] Open";
                break;

            case "show":
                label.text = "[E] Show";
                break;

            case "pickup":
                label.text = "[E] Pick up";
                break;

            case "build":
                label.text = "[E] Build";
                break;

            default:
                label.text = "[E] Interact";
                break;
        }
        ShowLabel();
    }
}
