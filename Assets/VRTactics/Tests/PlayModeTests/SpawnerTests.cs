using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using VRTactics.Utils;
using VRTactics.Utils.Tests;

namespace VRTactics.PlayModeTests
{
    public class SpawnerTests
    {
        [UnityTest]
        public IEnumerator Spawner_destroys_instantiated_objects()
        {
            const int objectsCountToSpawn = 5;

            var prefab = new GameObject("Prefab");
            var spawnPoint = new GameObject("sp").transform;
            var spawner = new GameObject("Spawner").AddComponent<Spawner>();

            SpawnerTestUtils.ConfigureSpawner(spawner, prefab, new[] {spawnPoint});

            var spawnedObjects = spawner.SpawnCollection(objectsCountToSpawn);
            spawner.Clean();

            yield return null;

            foreach (var t in spawnedObjects)
            {
                Assert.IsTrue(t == null);
            }

            Object.DestroyImmediate(prefab.gameObject);
            Object.DestroyImmediate(spawnPoint.gameObject);
            Object.DestroyImmediate(spawner.gameObject);

            foreach (var spawnedObject in spawnedObjects)
            {
                Object.DestroyImmediate(spawnedObject);
            }
        }
    }
}