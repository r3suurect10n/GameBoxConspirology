using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static Action OnTimerStart;

    public void OnSceneIndexLoad(string sceneName)
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            GameData.SetStartDay();
            GameData.InitializeNotebook();
        }
        else if (SceneManager.GetActiveScene().name == "HouseScene")
            OnTimerStart?.Invoke();

        SceneManager.LoadScene(sceneName);
    }

    public void OnGameQuit()
    {
        Application.Quit();
    }
}
