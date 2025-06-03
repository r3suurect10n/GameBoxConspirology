using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLookCamera : MonoBehaviour
{
    [Header("Components properties")]    
    [SerializeField] private Transform _playerCamera;

    [Header("Mouse properties")]
    [SerializeField] private float _mouseSensivityX;
    [SerializeField] private float _mouseSensivityY;

    [Header("Camera properties")]    
    [SerializeField] private float _maxCameraPitch;
        
    private Vector2 _mouseInput;
    private float _cameraPitch = 0f;

    private void Update()
    {
        float yaw = _mouseSensivityX * _mouseInput.x;
        transform.Rotate(Vector3.up * yaw);

        float pitch = _mouseSensivityY * _mouseInput.y;
        _cameraPitch -= pitch;
        _cameraPitch = Mathf.Clamp(_cameraPitch, -_maxCameraPitch, _maxCameraPitch);
        _playerCamera.localEulerAngles = new Vector3(_cameraPitch, 0f, 0f);
    }

    public void OnLook(InputAction.CallbackContext callbackContext)
    {
        _mouseInput = callbackContext.ReadValue<Vector2>();
    }

}
