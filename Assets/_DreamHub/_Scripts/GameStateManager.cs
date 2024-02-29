using UnityEngine;

namespace DreamHub
{
    public sealed class GameStateManager : PersistentSingleton<GameStateManager>
    {
        public enum GameState { Menu = 0, Dreaming = 1, Hub = 2, Pause = 3, GameOver = 4, }
        [field: SerializeField] public GameState CurrentGameState { get; private set; }

        protected override void Awake()
        {
            base.Awake();
        }

        public static void Set(GameState state)
        {
            Instance.CurrentGameState = state;
        }

        public static bool IsPlayerActive()
        {
            return true;
        }
    }
}