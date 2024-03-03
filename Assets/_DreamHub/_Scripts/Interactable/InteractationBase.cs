using UnityEngine;

namespace DreamHub.Interactable
{
    public abstract class InteractationBase : MonoBehaviour
    {
        protected bool _canInteract = true;

        public virtual bool TryInteract()
        {
            if (_canInteract)
            {
                _canInteract = false;
                return true;
            }

            return false;
        }
    }
}