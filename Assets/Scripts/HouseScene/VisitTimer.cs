using System;
using UnityEngine;
using UnityEngine.UI;

public class VisitTimer : MonoBehaviour
{
    public static Action<string> OnTimeGone; 

    [SerializeField] private Text _timerText;   

    private bool _timerRunning = false;
    private float _maxTime = 300f;
    private float _currentTime;

    private void OnEnable()
    {
        PanelFader.OnHouseScene += Timer;
    }

    private void OnDisable()
    {
        PanelFader.OnHouseScene -= Timer;
    }

    private void Start()
    {        
        _currentTime = _maxTime;
        _timerText.text = $"{(_currentTime / 60).ToString("00")}:{(_currentTime % 60).ToString("00")}";        
    }

    private void Update()
    {
        if (_timerRunning && _currentTime > 0f)
        {
            _currentTime -= Time.deltaTime;
            _timerText.text = $"{Mathf.Floor(_currentTime / 60):00}:{Mathf.Floor(_currentTime % 60):00}";
        }
        else if (_currentTime <= 0f)
        {
            _currentTime = 0f;
            GameData.SetNextDay();
            OnTimeGone?.Invoke("MapScene");
        }
    }

    private void Timer()
    {
        _timerRunning = true;
    }
}
