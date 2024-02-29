using System;
using UnityEngine;

namespace DreamHub.Dream
{
    public sealed class DreamModeManager : Singleton<DreamModeManager>
    {
        public enum DreamMode { Normal = 0, Lucid = 1, }
        [field: SerializeField] public DreamMode Current { get; private set; }
        public event Action<DreamMode> OnModeChanged;

        private void Start() => Set(DreamMode.Normal);

        public static void Set(DreamMode dreamMode)
        {
            Instance.Current = dreamMode;
            GravityReference.Set(dreamMode);

            Instance.OnModeChanged?.Invoke(Instance.Current);
        }
    }
}