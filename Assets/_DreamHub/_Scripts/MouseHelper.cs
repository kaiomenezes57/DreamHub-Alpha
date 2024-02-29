using UnityEngine;

namespace DreamHub
{
    public static class MouseHelper
    {
        public static void SwitchVisibility(bool state)
        {
            Cursor.visible = state;
            Cursor.lockState = state ? CursorLockMode.Confined : CursorLockMode.Locked;
        }
    }
}
