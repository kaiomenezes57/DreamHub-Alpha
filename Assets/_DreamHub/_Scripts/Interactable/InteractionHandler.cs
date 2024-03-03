using DreamHub.Dream;
using DreamHub.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DreamHub.Interactable
{
    public sealed class InteractionHandler : MonoBehaviour
    {
        [SerializeField] private PickableBoxHandler _pickableBoxHandler;
        private InteractationBase _currentInteraction;

        private void Start()
        {
            PlayerInputs.Inputs.Actions.Interact.performed += TryInteract;
        }

        private void Update()
        {
            if (!CanExecute()) { return; }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 3f))
            {
                if (hitInfo.collider.TryGetComponent(out _currentInteraction))
                {
                    return;
                }
            }

            _currentInteraction = null;
        }

        private void TryInteract(InputAction.CallbackContext ctx)
        {
            if (!CanExecute()) { return; }

            _currentInteraction?.TryInteract();
            _currentInteraction = null;
        }

        private bool CanExecute()
        {
            return DreamModeManager.Instance.Current == DreamModeManager.DreamMode.Lucid && !_pickableBoxHandler.IsHoldingBox;
        }

        private void OnDisable()
        {
            PlayerInputs.Inputs.Actions.Interact.performed -= TryInteract;
        }
    }
}
