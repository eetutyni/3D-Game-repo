using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
