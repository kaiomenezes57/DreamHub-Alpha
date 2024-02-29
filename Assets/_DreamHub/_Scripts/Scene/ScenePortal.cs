using UnityEngine;

namespace DreamHub.Scene
{
    public sealed class ScenePortal : TriggerBase
    {
        [SerializeField] private SceneData _sceneData;

        protected override void Trigger()
        {
            SceneController.LoadScene(_sceneData);
        }
    }
}
