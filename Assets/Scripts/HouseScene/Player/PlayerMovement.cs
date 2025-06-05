using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement properties")]
    [SerializeField, Range (0, 50)] private float _moveSpeed;

    private CharacterController _chController;
    private Vector2 _moveInput;

    private void Awake()
    {
        _chController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 move = _moveInput.x * transform.right + _moveInput.y * transform.forward;

        _chController.Move(move * _moveSpeed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        _moveInput = callbackContext.ReadValue<Vector2>();
    }
}
