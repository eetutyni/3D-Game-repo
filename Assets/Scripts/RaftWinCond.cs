using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftWinCond : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;

    private void OnTriggerEnter(Collider other)
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
