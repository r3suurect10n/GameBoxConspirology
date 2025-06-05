using System.Collections;
using Unity.Android.Types;
using UnityEngine;
using UnityEngine.UI;

public class MapInteraction : MonoBehaviour
{  
    [SerializeField] private GameObject[] _humanPanels;
    [SerializeField] private Button[] _mapButtons;
    [SerializeField] private GameObject _visitButton;
    private bool _showHumanPanel = false;
    
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

    public void OnSkipDayClick()
    {
        GameData.SetNextDay();

    }
}
