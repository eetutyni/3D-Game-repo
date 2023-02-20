using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance;
    public GameObject LoadingPanel;
    private string targetScene;
    public float MinLoadTime;
    public GameObject LoadingWheel;
    public float WheelSpeed;
    private bool isLoading;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);    
        }

        LoadingPanel.SetActive(false);
    }

    public void LoadScene (string sceneName)
    {
        targetScene = sceneName;
        StartCoroutine(LoadSceneRoutine());
    }

    private IEnumerator LoadSceneRoutine()
    {
        isLoading = true;
        LoadingPanel.SetActive(true);
        AsyncOperation op = SceneManager.LoadSceneAsync(targetScene);
        float elapsedLoadTime = 0f;

        StartCoroutine(SpinWheelRoutine());

        while (!op.isDone)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return null;
        }

        while(elapsedLoadTime < MinLoadTime)
        {
            elapsedLoadTime += Time.deltaTime; 
                yield return null;
        }


        LoadingPanel.SetActive(false);
        isLoading = false;
    }

    private IEnumerator SpinWheelRoutine() 
    {
        while (isLoading)
        {
            LoadingWheel.transform.Rotate(0, 0, -WheelSpeed);
            yield return null;
        }
    }
}
