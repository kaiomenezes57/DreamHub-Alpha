using UnityEngine;
using UnityEngine.Events;

namespace DreamHub.BHEvents
{
    public class BHEventListener : MonoBehaviour, IEventHandler
    {
        [SerializeField] private BHEvent _BHEvent;
        [SerializeField] private UnityEvent _unityEvent;

        private void Awake()
        {
            _BHEvent.Subscribe(this);
        }

        public void Raise()
        {
            _unityEvent?.Invoke();
        }

        private void OnDestroy()
        {
            _BHEvent.Unsubscribe(this);
        }
    }
}
