using DreamHub.Dream;
using System;
using System.Collections;
using UnityEngine;

namespace DreamHub.Aberration
{
    public sealed class AberrationLevel : MonoBehaviour
    {
        private float _level = 50f;

        private const float _defaultMultiplier = 3f;
        private float _multiplier;
        
        public static event Action<float> OnUpdated;
        public static event Action OnFullyReached;

        private void Start()
        {
            DreamModeManager.Instance.OnModeChanged += SetMultiplierByMode;
            SetMultiplierByMode(DreamModeManager.DreamMode.Normal);
            
            StartCoroutine(HandleLoop());
        }

        private IEnumerator HandleLoop()
        {
            while (_level < 100f)
            {
                _level = Mathf.Clamp(_level + (_multiplier * Time.unscaledDeltaTime), 0f, 100f);
                OnUpdated?.Invoke(_level);
                yield return null;
            }
        }

        private void SetMultiplierByMode(DreamModeManager.DreamMode mode)
        {
            switch (mode)
            {
                case DreamModeManager.DreamMode.Normal:
                    _multiplier = -(_defaultMultiplier * 2f);
                    break;

                case DreamModeManager.DreamMode.Lucid:
                    _multiplier = _defaultMultiplier;
                    break;
            }
        }
    }
}