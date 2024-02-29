using UnityEngine;

namespace DreamHub.Player
{
    public sealed class PlayerInputs : MonoBehaviour
    {
        public static Inputs Inputs;

        private void Awake()
        {
            Inputs = new();
            Inputs.Enable();
        }

        private void OnDestroy()
        {
            Inputs.Disable();
        }
    }
}
