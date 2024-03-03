using DreamHub.Dream;
using DreamHub.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DreamHub.Interactable
{
    public sealed class PickableBoxHandler : MonoBehaviour
    {
        public bool IsHoldingBox { get; private set; }
        private PickableBox _current;

        private void Start()
        {
            DreamModeManager.Instance.OnModeChanged += (mode) => {
                if (mode == DreamModeManager.DreamMode.Normal)
                {
                    Release(default);
                }
            };
        }

        public void Set(PickableBox pickableBox)
        {
            pickableBox.transform.SetParent(transform);
            pickableBox.transform.localPosition = Vector3.zero;
            pickableBox.transform.transform.localRotation = Quaternion.identity;

            _current = pickableBox;
            IsHoldingBox = true;

            PlayerInputs.Inputs.Actions.Interact.performed += Release;
        }

        public void Release(InputAction.CallbackContext ctx)
        {
            if (_current == null) { return; }

            _current.transform.SetParent(null);
            _current.Release();
            _current = null;

            IsHoldingBox = false;
            PlayerInputs.Inputs.Actions.Interact.performed -= Release;
        }
    }
}
