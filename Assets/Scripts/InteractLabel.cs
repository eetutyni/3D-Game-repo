using UnityEngine;
using TMPro;

public class InteractLabel : MonoBehaviour
{
    public bool seesInteractible;
    public bool seesShowable;
    public bool seesPickupable;
    public bool seesBuildable;

    private TextMeshProUGUI label;

    private void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (seesPickupable)
        {
            SetLabel("pickup");
        }
        else if (seesBuildable)
        {
            SetLabel("build");
        }
        else if (seesShowable)
        {
            SetLabel("show");
        }
        else if (seesInteractible)
        {
            SetLabel("interact");
        }
        else
        {
            HideLabel();
        }
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

            case "build":
                label.text = "[E] Build";
                ShowLabel();
                break;
        }
    }
}
