using DreamHub.Dream;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DreamHub.Player
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class PlayerMovement : MonoBehaviour
    {
        public bool IsMoving { get; private set; }
        public bool IsRunning { get; private set; }

        private readonly float _defaultPlayerSpeed = 2f;
        private float _currentPlayerSpeed;

        private Vector3 _motion;
        private CharacterController _characterController;
        public static event System.Action<bool, bool> OnMoving;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();

            PlayerInputs.Inputs.Actions.RunToggle.performed += SwitchRun;
            PlayerInputs.Inputs.Actions.RunToggle.canceled += SwitchRun;
            PlayerInputs.Inputs.Actions.Jump.performed += Jump;

            _currentPlayerSpeed = _defaultPlayerSpeed;
        }

        private void Update()
        {
            Move();
            GravityBehaviour();
            _characterController.Move(Time.unscaledDeltaTime * _motion);
        }

        private void Move()
        {
            if (!GameStateManager.IsPlayerActive()) { OnMoving?.Invoke(false, false); return; }
            if (!_characterController.enabled) { OnMoving?.Invoke(false, false); return; }

            float horizontal = PlayerInputs.Inputs.Actions.Horizontal.ReadValue<float>();
            float vertical = PlayerInputs.Inputs.Actions.Vertical.ReadValue<float>();

            OnMoving?.Invoke(SetIsWalking(horizontal, vertical), IsRunning);
            
            float normalY = _motion.y;
            _motion = _currentPlayerSpeed * (transform.forward * vertical + transform.right * horizontal);
            _motion.y = normalY;
        }

        private void SwitchRun(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                IsRunning = true;
                _currentPlayerSpeed = _defaultPlayerSpeed * 2f;
                return;
            }

            IsRunning = false;
            _currentPlayerSpeed = _defaultPlayerSpeed;
        }

        private void Jump(InputAction.CallbackContext ctx)
        {
            if (!_characterController.isGrounded) { return; }
            
            _motion.y = 0f;
            _motion.y += 5f;
        }

        public void GravityBehaviour()
        {
            if (_characterController.isGrounded) { return; }
            _motion.y += GravityReference.Current * Time.unscaledDeltaTime;
        }

        private bool SetIsWalking(float horizontal, float vertical)
        {
            IsMoving = horizontal != 0 || vertical != 0;
            return IsMoving;
        }

        private void OnDestroy()
        {
            PlayerInputs.Inputs.Actions.RunToggle.performed -= SwitchRun;
            PlayerInputs.Inputs.Actions.RunToggle.canceled -= SwitchRun;
            PlayerInputs.Inputs.Actions.Jump.performed -= Jump;
        }
    }
}
