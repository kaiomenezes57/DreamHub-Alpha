namespace DreamHub
{
    public sealed class GameManager : Singleton<GameManager>
    {
        public enum GameState { Menu = 0, Dreaming = 1, Hub = 2, Pause = 3, GameOver = 4, }
        public GameState CurrentGameState { get; private set; }

        public static void SetGameState(GameState state)
        {
            Instance.CurrentGameState = state;
        }

        public static bool IsPlayerActive()
        {
            return true;
        }
    }
}