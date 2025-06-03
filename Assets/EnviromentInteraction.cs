using UnityEngine;

public class EnviromentInteraction : MonoBehaviour
{
    [Header("Interaction tip objects")]
    [SerializeField] private GameObject _interactionTipPanel;    

    private void OnTriggerEnter(Collider other)
    {
        ShowTip(other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        ShowTip(other, false);
    }

    private void ShowTip(Collider entity, bool show)
    {
        if (entity.GetComponent<PlayerMovement>())
            _interactionTipPanel.SetActive(show);
    }
}
