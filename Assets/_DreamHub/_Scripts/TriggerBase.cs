using UnityEngine;

namespace DreamHub
{
    public abstract class TriggerBase : MonoBehaviour
    {
        [SerializeField] protected bool _triggerOnce = true;

        private void Awake() => GetComponent<BoxCollider>().isTrigger = true;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) { return; }
            Trigger();

            if (_triggerOnce)
            {
                Destroy(gameObject);
            }
        }

        protected abstract void Trigger();
    }
}
