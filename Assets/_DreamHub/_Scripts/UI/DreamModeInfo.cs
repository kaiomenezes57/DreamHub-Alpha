using DreamHub.Dream;
using TMPro;
using UnityEngine;

namespace DreamHub.UI
{
    public sealed class DreamModeInfo : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        private Animator _animator;

        private void Start()
        {
            _text = GetComponentInChildren<TextMeshProUGUI>();
            _animator = GetComponent<Animator>();
            
            _text.text = string.Empty;
            DreamModeManager.Instance.OnModeChanged += Refresh;
        }

        private void Refresh(DreamModeManager.DreamMode dreamMode)
        {
            _text.text = $"Dream Mode: {dreamMode}";
            _animator.Play(0);
        }
    }
}
