using System;
using UnityEngine;

namespace DreamHub
{
    public sealed class DreamModeManager : Singleton<DreamModeManager>
    {
        public enum DreamMode { Normal = 0, Lucid = 1, }
        [field: SerializeField] public DreamMode Current { get; private set; }
        public event Action<DreamMode> OnModeChanged;

        public static void Set(DreamMode dreamMode)
        {
            Instance.Current = dreamMode;
            GravityReference.Set(dreamMode);

            Instance.OnModeChanged?.Invoke(Instance.Current);
        }
    }
}