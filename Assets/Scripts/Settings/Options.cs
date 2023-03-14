using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
    public Toggle FullScreenTog, VsyncTog;
    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedResolution;
    [SerializeField] Toggle AudioToggle;

    public TMP_Text resolutionText;
    void Start()
    {
        if (AudioListener.volume == 0)
        {
            AudioToggle.isOn = false;
        }
        FullScreenTog.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            VsyncTog.isOn = false;
        }
        else
        {
            VsyncTog.isOn = true;
        }

        bool foundRes = false;
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;

                selectedResolution = i;

                UpdateRes();
            }
        }
        if (!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;
            resolutions.Add(newRes);
            selectedResolution = resolutions.Count - 1;

            UpdateRes();
        }
    }

    public void ResLeft()
    {
        selectedResolution--;

        if (selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        UpdateRes();
    }
    public void ResRight()
    {
        selectedResolution++;
        if (selectedResolution > resolutions.Count - 1)
        {
            selectedResolution = resolutions.Count - 1;
        }
        UpdateRes();
    }

    public void UpdateRes()
    {
        resolutionText.text = resolutions[selectedResolution].horizontal.ToString() + "x" + resolutions[selectedResolution].vertical.ToString();
    }

    public void Applychanges()
    {
        if (VsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, FullScreenTog.isOn);
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
