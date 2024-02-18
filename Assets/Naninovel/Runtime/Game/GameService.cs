using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Naninovel.Runtime.Game
{
    [InitializeAtRuntime]
    public class GameService : IEngineService
    {
        private readonly List<string> rewardItems = new();
        private string label;
        private string currentLevelName;

        public UniTask InitializeServiceAsync()
        {
            return UniTask.CompletedTask;
        }

        public void LoadGame(string nameScene)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nameScene, LoadSceneMode.Additive);
            if (asyncOperation == null)
            {
                Debug.LogError("Не удается загрузить уровень " + nameScene);
                return;
            }

            asyncOperation.completed += OnLoadOperationComplete;

            currentLevelName = nameScene;
        }

        private void OnLoadOperationComplete(AsyncOperation obj)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentLevelName));
        }

        public void UnLoadGame(params string[] dependentScenes)
        {
            ReturnToNaninovelInLabel();

            UnloadLevel(currentLevelName, dependentScenes);
        }

        private void UnloadLevel(string sceneName, string[] dependentScenes)
        {
            AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(sceneName);

            asyncOperation.completed += _ => OnUnloadOperationComplete(dependentScenes);
        }

        private void OnUnloadOperationComplete(string[] dependentScenes)
        {
            if (dependentScenes.Length > 0)
                foreach (string dependentScene in dependentScenes)
                    SceneManager.UnloadSceneAsync(dependentScene);
        }

        private void ReturnToNaninovelInLabel()
        {
            ScriptPlayer scriptPlayer = Engine.GetService<ScriptPlayer>();
            Script script = scriptPlayer.PlayedScript;
            int line = script.GetLineIndexForLabel(label);
            scriptPlayer.Play(script, line);
        }

        public void ResetService()
        {
        }

        public void AddReward(string nameReward)
        {
            if (!rewardItems.Contains(nameReward))
                rewardItems.Add(nameReward);
        }

        public bool ContainsReward(string itemId) => rewardItems.Contains(itemId);
        public void SetLabel(string nameValue) => label = nameValue;
        public void ResetGame() => rewardItems.Clear();

        public void DestroyService()
        {
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}