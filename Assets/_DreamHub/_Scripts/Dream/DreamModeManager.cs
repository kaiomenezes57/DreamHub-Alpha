using DreamHub.Player;
using System;
using UnityEngine;

namespace DreamHub.Dream
{
    public sealed class DreamModeManager : Singleton<DreamModeManager>
    {
        public enum DreamMode { Normal = 0, Lucid = 1, }
        [field: SerializeField] public DreamMode Current { get; private set; }
        public event Action<DreamMode> OnModeChanged;

        private void Start()
        {
            PlayerInputs.Inputs.Actions.SwitchDreamMode.performed += InputHandle;
        }

        private void InputHandle(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            DreamMode nextMode = Current == DreamMode.Normal ? DreamMode.Lucid : DreamMode.Normal;
            Set(nextMode);
        }

        public static void Set(DreamMode dreamMode)
        {
            if (dreamMode == Instance.Current) { return; }

            Instance.Current = dreamMode;
            GravityReference.Set(dreamMode);

            Instance.OnModeChanged?.Invoke(Instance.Current);
        }

        private void OnDisable()
        {
            PlayerInputs.Inputs.Actions.SwitchDreamMode.performed -= InputHandle;
        }
    }
}