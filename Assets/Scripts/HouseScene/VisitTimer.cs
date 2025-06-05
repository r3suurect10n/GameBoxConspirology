using UnityEngine;
using UnityEngine.UI;

public class VisitTimer : MonoBehaviour
{
    [SerializeField] private Text _timerText;

    [SerializeField] private bool _timerRunning = false;
    private float _maxTime = 300;
    private float _currentTime;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Start()
    {
        _currentTime = _maxTime;
        _timerText.text = $"{(_currentTime / 60).ToString("00")}:{(_currentTime % 60).ToString("00")}";
    }

    private void Update()
    {
        if (_timerRunning && _currentTime >= 0)
        {
            _currentTime -= Time.deltaTime;
            _timerText.text = $"{Mathf.Floor(_currentTime / 60).ToString("00")}:{Mathf.Floor(_currentTime % 60).ToString("00")}";
        }
    }

    private void Timer()
    {
        _timerRunning = true;
    }
}
