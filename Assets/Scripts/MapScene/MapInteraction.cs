using UnityEngine;
using UnityEngine.UI;

public class MapInteraction : MonoBehaviour
{        
    [SerializeField] private Button[] _mapButtons;
    [SerializeField] private GameObject _visitButton;

    private bool _showHumanPanel = false; 

    public void OnMapButtonClick(GameObject _humanInfo)
    {
        _showHumanPanel = !_showHumanPanel;
        foreach (Button button in _mapButtons)
        {
            button.interactable = !_showHumanPanel;
        }

        _humanInfo.SetActive(_showHumanPanel);
        _visitButton.SetActive(_showHumanPanel);
    }    

    public void OnSkipDayClick()
    {
        GameData.SetNextDay();
    }
}
