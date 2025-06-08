using System.Collections;
using UnityEngine;

public class PanelShowing : MonoBehaviour
{
    [SerializeField] private GameObject _notebookUpdatedPanel;

    private bool _showPanel = false;

    private void OnEnable()
    {
        GameData.OnAddNote += NotebookUpdated;
    }

    private void OnDisable()
    {
        GameData.OnAddNote -= NotebookUpdated;
    }

    public void OnShowPanelButtonClick(GameObject panel)
    {
        _showPanel = !_showPanel;
        panel.SetActive(_showPanel);
    }

    private void NotebookUpdated()
    {
        StartCoroutine(NotebookUpdatedPanelShowing());
    }

    private IEnumerator NotebookUpdatedPanelShowing() 
    {
        _notebookUpdatedPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        _notebookUpdatedPanel.SetActive(false);

        StopCoroutine(NotebookUpdatedPanelShowing());
    }
}
