using System.Collections;
using UnityEngine;

namespace DreamHub.Dream
{
    public class DreamTimescale : MonoBehaviour
    {
        private void Start() => DreamModeManager.Instance.OnModeChanged += Set;

        private void Set(DreamModeManager.DreamMode dreamMode)
        {
            StopAllCoroutines();

            bool mustFreezeTime = dreamMode == DreamModeManager.DreamMode.Lucid;
            StartCoroutine(Animate(mustFreezeTime));
        }

        private IEnumerator Animate(bool mustFreezeTime)
        {
            float multiplier = mustFreezeTime ? -5f : 5f;
            float target = mustFreezeTime ? 0f : 1f;
            bool whileCondition = mustFreezeTime ? Time.timeScale > 0f : Time.timeScale < 1f;

            while (whileCondition)
            {
                Time.timeScale = Mathf.Clamp(Time.timeScale + (multiplier * Time.unscaledDeltaTime), 0f, 1f);
                yield return null;
            }

            Time.timeScale = target;
        }
    }
}