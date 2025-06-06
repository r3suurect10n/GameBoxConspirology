using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelFader : MonoBehaviour
{
    public static Action OnHouseScene;
    public static Action<string> OnFadeEnd;

    [Header("Fade properties")]
    [SerializeField] private GameObject _fadePanel;
    [SerializeField] private float _fadeDuration;

    private Coroutine _fadeCoroutine;
    private Image _fadeImage;
    private Color _fadeColor;
    private float _fadeTime;

    private void OnEnable()
    {
        VisitTimer.OnTimeGone += OnSceneTransition;
        InteractorBehavior.OnExit += OnSceneTransition;
    }

    private void OnDisable()
    {
        VisitTimer.OnTimeGone -= OnSceneTransition;
        InteractorBehavior.OnExit -= OnSceneTransition;
    }

    private void Awake()
    {        
        _fadeImage = _fadePanel.GetComponent<Image>();
        _fadeColor = _fadeImage.color;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
            OnSceneLoad();
    }

    public void OnSceneLoad()
    {
        _fadePanel.SetActive(true);
        if (_fadeCoroutine == null)
            _fadeCoroutine = StartCoroutine(StartUnfade());
    }

    public void OnSceneTransition(string loadSceneName)
    {
        if (_fadeCoroutine == null)
            _fadeCoroutine = StartCoroutine(StartFade(loadSceneName));
    }
    private IEnumerator StartUnfade()
    {
        _fadeTime = _fadeDuration;        

        while (_fadeTime >= 0)
        {
            _fadeColor.a = _fadeTime / _fadeDuration;
            _fadeTime -= Time.deltaTime;
            _fadeImage.color = _fadeColor;
            yield return null;
        }

        if (SceneManager.GetActiveScene().name == "HouseScene")
            OnHouseScene?.Invoke();

        _fadePanel.SetActive(false);
        StopCoroutine(_fadeCoroutine);
        _fadeCoroutine = null;
    }

    private IEnumerator StartFade(string loadSceneName)
    {
        _fadePanel.SetActive(true);        
        _fadeTime = 0;

        while (_fadeTime <= _fadeDuration)
        {
            _fadeColor.a = _fadeTime / _fadeDuration;
            _fadeTime += Time.deltaTime;
            _fadeImage.color = _fadeColor;

            yield return null;
        }

        OnFadeEnd?.Invoke(loadSceneName);
    }

}
