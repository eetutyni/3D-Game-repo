using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject visualSettingsPanel;
    [SerializeField] private GameObject audioSettingsPanel;
    [SerializeField] private GameObject inputSettingsPanel;

    public void SwapSettingsScreen()
    {
        visualSettingsPanel.SetActive(!visualSettingsPanel.activeInHierarchy);
        audioSettingsPanel.SetActive(!audioSettingsPanel.activeInHierarchy);
        inputSettingsPanel.SetActive(!inputSettingsPanel.activeInHierarchy);
    }
}
