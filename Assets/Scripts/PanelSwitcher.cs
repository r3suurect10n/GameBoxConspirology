using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _currentPanel;

    public void SwitchScreenOnClick(GameObject switchingPanel)
    {
        if (_currentPanel != null)
        {
            _currentPanel.SetActive(false);
        }

        switchingPanel.SetActive(true);
        _currentPanel = switchingPanel;
    }
}
