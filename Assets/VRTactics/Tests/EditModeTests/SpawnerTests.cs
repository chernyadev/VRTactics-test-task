using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using VRTactics.Utils;

namespace VRTactics.EditModeTests
{
    public class SpawnerTests : MonoBehaviour
    {
        [Test]
        public void Spawner_spawns_correct_amount_of_prefabs()
        {
            const int objectsCountToSpawn = 5;

            var prefab = new GameObject("Prefab");
            var spawnPoint = new GameObject("sp").transform;
            var spawner = new GameObject("Spawner").AddComponent<Spawner>();
            
            ConfigureSpawner(spawner, prefab, new[] {spawnPoint});
            
            var spawnedObjects = spawner.SpawnCollection(objectsCountToSpawn);
            
            Assert.AreEqual(objectsCountToSpawn, spawnedObjects.Count);
        }

        [Test]
        public void Spawner_spawns_prefabs_at_correct_positions()
        {
            const int objectsCountToSpawn = 10;

            var prefab = new GameObject("Prefab");
            var spawnPoint1 = new GameObject("sp1").transform;
            spawnPoint1.position = new Vector3(0, 0, 0);
            var spawnPoint2 = new GameObject("sp2").transform;
            spawnPoint2.position = new Vector3(30, 30, 30);
            var spawnPoints = new[] {spawnPoint1, spawnPoint2};
            
            var spawner = new GameObject("Spawner").AddComponent<Spawner>();
            ConfigureSpawner(spawner, prefab, spawnPoints);

            var spawnedObjects = spawner.SpawnCollection(objectsCountToSpawn);

            for (var i = 0; i < spawnedObjects.Count; i++)
            {
                var spawnPoint = spawnPoints[i % spawnPoints.Length];
                Assert.AreEqual(spawnPoint.position, spawnedObjects[i].transform.position);
            }
        }

        private static void ConfigureSpawner(Spawner spawner, GameObject prefab, Transform[] spawnPoints)
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