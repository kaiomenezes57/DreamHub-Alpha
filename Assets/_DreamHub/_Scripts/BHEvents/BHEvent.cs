using System.Collections.Generic;
using UnityEngine;

namespace DreamHub.BHEvents
{
    [CreateAssetMenu(menuName = "Scriptables/BHEvent")]
    public sealed class BHEvent : ScriptableObject, IEventHandler
    {
        private readonly HashSet<BHEventListener> _listeners = new();

        public void Subscribe(BHEventListener listener)
        {
            if (_listeners.Contains(listener)) { return; }
            _listeners.Add(listener);
        }

        public void Raise()
        {
            foreach (BHEventListener listener in _listeners)
            {
                listener?.Raise();
            }
        }

        public void Unsubscribe(BHEventListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}