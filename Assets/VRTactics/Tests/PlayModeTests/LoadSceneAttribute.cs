using System.Collections;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace VRTactics.PlayModeTests
{
    public class LoadSceneAttribute : NUnitAttribute, IOuterUnityTestAction
    {
        private readonly string _scenePath;
        private EditorBuildSettingsScene[] _originalScenesInBuild;

        public LoadSceneAttribute(string scenePath)
        {
            _scenePath = scenePath;
        }

        public IEnumerator BeforeTest(ITest test)
        {
            _originalScenesInBuild = EditorBuildSettings.scenes;
            var sceneSettings = new EditorBuildSettingsScene[1];
            var sceneToAdd = new EditorBuildSettingsScene(_scenePath, true);
            sceneSettings[sceneSettings.Length - 1] = sceneToAdd;
            EditorBuildSettings.scenes = sceneSettings;

            yield return EditorSceneManager.LoadSceneAsyncInPlayMode(_scenePath, new LoadSceneParameters(LoadSceneMode.Single));
        }

        public IEnumerator AfterTest(ITest test)
        {
            EditorBuildSettings.scenes = _originalScenesInBuild;
            yield return null;
        }
    }
}