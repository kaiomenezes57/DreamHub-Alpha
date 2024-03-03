using DreamHub.Dream;
using System.Collections;
using UnityEngine;

namespace DreamHub.Interactable
{
    public sealed class PickableBox : InteractationBase
    {
        private PickableBoxHandler _pickableBoxHandler;
        private Rigidbody _rigidBody;

        private float _initialScale;
        private float _minorScale;

        private void Start()
        {
            _initialScale = transform.localScale.x;
            _minorScale = _initialScale / 2f;
            
            _pickableBoxHandler = FindObjectOfType<PickableBoxHandler>();
            _rigidBody = GetComponent<Rigidbody>();

            DreamModeManager.Instance.OnModeChanged += (state) => {
                _rigidBody.isKinematic = state == DreamModeManager.DreamMode.Lucid;
            };
        }

        public override bool TryInteract()
        {
            if (base.TryInteract())
            {
                _pickableBoxHandler.Set(this);
                StartCoroutine(PopdownAnimation());
                return true;
            }

            return false;
        }

        public void Release()
        {
            _canInteract = true;
            StartCoroutine(PopupAnimation());
        }

        private IEnumerator PopdownAnimation()
        {
            float value = _initialScale;

            while (transform.localScale.x > _minorScale)
            {
                value -= Time.unscaledDeltaTime * 2f;
                transform.localScale = new Vector3(value, value, value);
                yield return null;
            }
        }

        private IEnumerator PopupAnimation()
        {
            float value = _minorScale;

            while (transform.localScale.x < _initialScale)
            {
                value += Time.unscaledDeltaTime * 2f;
                transform.localScale = new Vector3(value, value, value);
                yield return null;
            }
        }
    }
}