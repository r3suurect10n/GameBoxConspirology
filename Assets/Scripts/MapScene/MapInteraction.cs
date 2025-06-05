using System.Collections;
using Unity.Android.Types;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapInteraction : MonoBehaviour
{
    [SerializeField] private GameObject _exitPanel;

    [SerializeField] private GameObject[] _humanPanels;
    [SerializeField] private Button[] _mapButtons;
    [SerializeField] private GameObject _visitButton;
    private bool _showHumanPanel = false;

    [SerializeField] private Image _fadePanel;
    [SerializeField] private float _maxFadeSeconds;
    private float _currentFadeSeconds;
    
    public void OnMapButtonClick(int houseIndex)
    {
        _showHumanPanel = !_showHumanPanel;
        foreach (Button button in _mapButtons)
        {             
            button.interactable = !_showHumanPanel;
        }

        _humanPanels[houseIndex].SetActive(_showHumanPanel);
        _visitButton.SetActive(_showHumanPanel);
    }
    
    public void OnSceneTransition(int sceneIndex)
    {
        StartCoroutine(TransitionFade(sceneIndex));
    }

    public void OnExitButtonClick()
    {

    }

    private IEnumerator TransitionFade(int sceneIndex)
    {
        //Image image = _fadePanel.GetComponent<Image>();

        _currentFadeSeconds = _maxFadeSeconds;

        while (_currentFadeSeconds >= 0)
        {
            _currentFadeSeconds -= Time.deltaTime;
            //_fadePanel.color.a = _currentFadeSeconds / _maxFadeSeconds;
        }

        SceneManager.LoadScene(sceneIndex);
        yield return null;        
    }
}
