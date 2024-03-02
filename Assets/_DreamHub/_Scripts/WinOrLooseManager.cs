using DreamHub.SaveGame;
using DreamHub.Scene;
using UnityEngine;

namespace DreamHub
{
    public sealed class WinOrLooseManager : Singleton<WinOrLooseManager>
    {
        [SerializeField] private SceneData _afterDieScene;
        private bool _mustWin;

        public static void SetLevelCompleted()
        {
            Instance._mustWin = true;
        }

        public static void OnPlayerDied()
        {
            if (Instance._mustWin)
            {
                LevelSaveLoadManager.IncrementAndSave();
                Debug.Log("Ganhou");
            }

            Debug.Log("Perdeu");
            SceneController.LoadScene(Instance._afterDieScene);
        }
    }
}