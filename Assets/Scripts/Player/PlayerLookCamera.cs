using Unity.Cinemachine;
using UnityEngine;

public class PlayerLookCamera : MonoBehaviour
{
    [Header("Components properties")]
    [SerializeField] private Transform _player;
    [SerializeField] private CinemachineCamera _playerCamera;

    [Header("Mouse properties")]
    [SerializeField] private float _mouseSensivity;

    private void Update()
    {
        _player.rotation = Quaternion.Euler(0, _playerCamera.transform.rotation.y, 0);
    }

}
