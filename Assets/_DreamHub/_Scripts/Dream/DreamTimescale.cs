using UnityEngine;

namespace DreamHub.Dream
{
    public class DreamTimescale : MonoBehaviour
    {
        private void Start() => DreamModeManager.Instance.OnModeChanged += Set;

        private void Set(DreamModeManager.DreamMode obj)
        {
            Time.timeScale = GetTimescaleByMode(obj);
        }

        private float GetTimescaleByMode(DreamModeManager.DreamMode mode)
        {
            return mode switch
            {
                DreamModeManager.DreamMode.Normal => 1f,
                DreamModeManager.DreamMode.Lucid => 0f,
                _ => 1f,
            };
        }
    }
}