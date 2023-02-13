using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapBush : MonoBehaviour
{


    [SerializeField] private GameObject bush;
    [SerializeField] private GameObject blueberrybush;

    public void Swap()
    {
        bush.SetActive(true);
        blueberrybush.SetActive(false);
    }
}
