using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Parts : MonoBehaviour
{
    int parts = 0;

    [SerializeField] TextMeshProUGUI partsText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("part"))
        {
            partsText.gameObject.SetActive(true);
            Destroy(other.gameObject);
            parts++;
            partsText.text = "Parts: " + parts + " / 4";
            StartCoroutine(Waiter());
        }
    }
    
    private IEnumerator Waiter()
    {
        yield return new WaitForSeconds(4);
            partsText.gameObject.SetActive(false);
    }
}
