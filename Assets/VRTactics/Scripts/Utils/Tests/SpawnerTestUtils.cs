using UnityEditor;
using UnityEngine;

namespace VRTactics.Utils.Tests
{
    public static class SpawnerTestUtils
    {
        public static void ConfigureSpawner(Spawner spawner, GameObject prefab, Transform[] spawnPoints)
        {
            var serializedSpawner = new SerializedObject(spawner);

            var prefabProp = serializedSpawner.FindProperty("prefab");
            var spawnPointsProp = serializedSpawner.FindProperty("spawnPoints");

            prefabProp.objectReferenceValue = prefab;
            spawnPointsProp.arraySize = spawnPoints.Length;
            for (var i = 0; i < spawnPoints.Length; i++)
            {
                spawnPointsProp.GetArrayElementAtIndex(i).objectReferenceValue = spawnPoints[i];
            }

            serializedSpawner.ApplyModifiedProperties();
        }
    }
}