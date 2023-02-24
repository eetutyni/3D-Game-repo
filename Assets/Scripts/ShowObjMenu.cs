using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjMenu : MonoBehaviour
{
    [SerializeField] private GameObject objCanvas;
    [SerializeField] private GameObject tipCanv;

    private bool tipsActive = true;
    private bool objactive = false;

    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        
        if(timer > 10)
        {
            tipsActive= false;
            tipCanv.SetActive(false);
        } 

        if (Input.GetKeyDown(KeyCode.N))
        {
            objCanvas.SetActive(!objactive);

            objactive = !objactive;

            if (tipsActive)
            {
                tipCanv.SetActive(false);
                tipsActive = false;
            }
        }
    }
}
