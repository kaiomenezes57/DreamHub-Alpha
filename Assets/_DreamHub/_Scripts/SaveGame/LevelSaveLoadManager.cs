using UnityEngine;

namespace DreamHub.SaveGame
{
    public sealed class LevelSaveLoadManager : PersistentSingleton<LevelSaveLoadManager>
    {
        [field: SerializeField] public int CurrentLevelIndex { get; private set; } = 0;
        private const string _key = "LevelIndex";

        protected override void Awake()
        {
            base.Awake();
            CurrentLevelIndex = Load();
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("DreamHub/Save _F11")]
#endif
        public static void IncrementAndSave()
        {
            BayatGames.SaveGameFree.SaveGame.Save(_key, ++Instance.CurrentLevelIndex);
            Instance.CurrentLevelIndex = Instance.Load();
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("DreamHub/Delete Save _F12")]
#endif
        public static void DeleteSave()
        {
            if (!BayatGames.SaveGameFree.SaveGame.Exists(_key)) { return; }

            BayatGames.SaveGameFree.SaveGame.Delete(_key);
            Instance.CurrentLevelIndex = Instance.Load();
        }

        private int Load()
        {
            if (!BayatGames.SaveGameFree.SaveGame.Exists(_key)) { return 0; }
            return BayatGames.SaveGameFree.SaveGame.Load<int>(_key);
        }
    }
}
