using Cinemachine;
using UnityEngine;

namespace DreamHub.Player
{
    public sealed class PlayerCamera : MonoBehaviour
    {
        private CinemachineVirtualCamera _virtualCamera;
        private readonly float _sensitivity = 0.1f;
        private float _rotationX;

        private void Start()
        {
            _virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
            MouseHelper.SwitchVisibility(false);
        }

        private void Update()
        {
            if (!GameStateManager.IsPlayerActive()) { return; }
            float mouseX = PlayerInputs.Inputs.Actions.CameraMovement.ReadValue<Vector2>().x * _sensitivity;
            float mouseY = PlayerInputs.Inputs.Actions.CameraMovement.ReadValue<Vector2>().y * _sensitivity;

            _rotationX -= mouseY;
            _rotationX = Mathf.Clamp(_rotationX, -60f, 80f);

            transform.Rotate(0f, mouseX, 0f);
            _virtualCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
        }
    }
}
