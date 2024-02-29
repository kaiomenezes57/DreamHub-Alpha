using UnityEngine;

namespace DreamHub.Scene
{
    [CreateAssetMenu(menuName = "Scriptables/Scene")]
    public class SceneData : ScriptableObject
    {
        public string Name;
        public GameStateManager.GameState InitialState;
    }
}
