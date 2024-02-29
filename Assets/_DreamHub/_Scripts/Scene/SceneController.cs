using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DreamHub.Scene
{
    public class SceneController : PersistentSingleton<SceneController>
    {
        [field: SerializeField] public SceneData Current { get; private set; }
        public event Action<SceneData> OnChangeScene;

        protected override void Awake()
        {
            base.Awake();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public static void LoadScene(SceneData sceneData)
        {
            SceneManager.LoadScene(sceneData.Name, LoadSceneMode.Single);
            Instance.Current = sceneData;
        }

        private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode loadSceneMode)
        {
            if (Current == null) { return; }

            GameStateManager.Set(Current.InitialState);
            OnChangeScene?.Invoke(Current);
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}