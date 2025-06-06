using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        PanelFader.OnFadeEnd += OnSceneNameLoad;
    }

    private void OnDisable()
    {
        PanelFader.OnFadeEnd -= OnSceneNameLoad;
    }

    public void OnSceneNameLoad(string sceneName)
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            GameData.SetStartDay();
            GameData.InitializeNotebook();
        }

        StartCoroutine(WaitForSound(sceneName));         
    }

    public void OnGameQuit()
    {
        Application.Quit();
    }

    private IEnumerator WaitForSound(string sceneName)
    {
        while (_audioSource.isPlaying)
            yield return null;

        SceneManager.LoadScene(sceneName);
    }
}
