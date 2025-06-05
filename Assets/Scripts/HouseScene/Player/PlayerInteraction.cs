using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{  
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _interactionTip;
    [SerializeField, Range(0, 10)] private float _interactDistance;
    [SerializeField] private LayerMask _interactableLayerMask;

    private InteractorBehavior _currentInteractor;
    private EvidenceCollect _currentEvidence;

    private Ray _playerLookRay;
    private RaycastHit _playerLookHit;
    

    private void Update()
    {
        _playerLookRay = _camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        Debug.DrawRay(_playerLookRay.origin, _playerLookRay.direction * _interactDistance, Color.red);

        if (Physics.Raycast(_playerLookRay, out _playerLookHit, _interactDistance, _interactableLayerMask))
        {            
            _currentInteractor = _playerLookHit.collider.GetComponent<InteractorBehavior>();                       
            _currentEvidence = _playerLookHit.collider.GetComponent<EvidenceCollect>();            
        }
        else
        {           
            _currentEvidence = null;
            _currentInteractor = null;
        }

        _interactionTip.SetActive(_currentEvidence != null || _currentInteractor != null);        
    }

    public void OnInteract(InputAction.CallbackContext _callbackContext)
    {
        if (_callbackContext.phase != InputActionPhase.Started)
            return;
        
        if (_currentInteractor != null)
            _currentInteractor.InteractorOpenClose();
        else if (_currentInteractor != null)
        {
        }        
    }    
}
