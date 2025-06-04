using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public static Action OnDoorInteract;
    public static Action OnEvidenceInteract;

    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _interactionTip;
    [SerializeField, Range(0, 10)] private float _interactDistance;

    private Ray _playerLookRay;
    private RaycastHit _playerLookHit;

    private bool _isInteractable;

    private void Update()
    {
        _playerLookRay = _camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        Debug.DrawRay(_playerLookRay.origin, _playerLookRay.direction * _interactDistance, Color.red);

        _isInteractable = (Physics.Raycast(_playerLookRay, out _playerLookHit, _interactDistance)) && (_playerLookHit.collider.GetComponent<Door>());
        _interactionTip.SetActive(_isInteractable);       
    }

    public void OnInteract(InputAction.CallbackContext _callbackContext)
    {
        if (Physics.Raycast(_playerLookRay, out _playerLookHit, _interactDistance))
        {
            if (_callbackContext.phase == InputActionPhase.Started)
            {
                if (_playerLookHit.collider.GetComponent<Door>())
                {
                    OnDoorInteract?.Invoke();
                }
                else if (_playerLookHit.collider.GetComponent<Door>())
                {
                    OnEvidenceInteract?.Invoke();
                }
            }
        }
    }    
}
