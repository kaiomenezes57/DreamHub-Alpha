using UnityEngine;

namespace DreamHub.Dream
{
    public sealed class OnChangeDreamModeSound : MonoBehaviour
    {
        private void Start()
        {
            DreamModeManager.Instance.OnModeChanged += PlayByMode;
        }

        private void PlayByMode(DreamModeManager.DreamMode dreamMode)
        {
            switch (dreamMode)
            {
                case DreamModeManager.DreamMode.Normal:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/2D/OnEnterNormalDream");
                    break;

                case DreamModeManager.DreamMode.Lucid:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/2D/OnEnterLucidDream");
                    break;
            }
        }
    }
}