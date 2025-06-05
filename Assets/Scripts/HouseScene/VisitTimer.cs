using UnityEngine;
using UnityEngine.UI;

public class VisitTimer : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    
    private SceneManagement _sceneManagement;

    private bool _timerRunning = false;
    private float _maxTime = 61;
    private float _currentTime;

    private void OnEnable()
    {
        SceneManagement.OnTimerStart += Timer;
    }

    private void OnDisable()
    {
        SceneManagement.OnTimerStart -= Timer;
    }

    private void Start()
    {
        _sceneManagement = GetComponent<SceneManagement>();

        _currentTime = _maxTime;
        _timerText.text = $"{(_currentTime / 60).ToString("00")}:{(_currentTime % 60).ToString("00")}";
        Timer();
    }

    private void Update()
    {
        if (_timerRunning && _currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            _timerText.text = $"{Mathf.Floor(_currentTime / 60):00}:{Mathf.Floor(_currentTime % 60):00}";
        }
        else if (_currentTime <= 0)
            _sceneManagement.OnSceneIndexLoad("MapScene");
    }

    private void Timer()
    {
        _timerRunning = true;
    }
}
