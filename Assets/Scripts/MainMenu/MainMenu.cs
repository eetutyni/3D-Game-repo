using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {


    }

    public void SettingsButton()
    {
        SceneManager.LoadScene("Settings");

    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void SettingsBackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
