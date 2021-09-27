using NUnit.Framework;
using UnityEngine;
using VRTactics.Utils;
using VRTactics.Utils.Tests;

namespace VRTactics.EditModeTests
{
    public class SpawnerTests
    {
        [Test]
        public void Spawner_spawns_correct_amount_of_prefabs()
        {
            const int objectsCountToSpawn = 5;

            var prefab = new GameObject("Prefab");
            var spawnPoint = new GameObject("sp").transform;
            var spawner = new GameObject("Spawner").AddComponent<Spawner>();

            SpawnerTestUtils.ConfigureSpawner(spawner, prefab, new[] {spawnPoint});

            var spawnedObjects = spawner.SpawnCollection(objectsCountToSpawn);

            Assert.AreEqual(objectsCountToSpawn, spawnedObjects.Count);

            Object.DestroyImmediate(prefab.gameObject);
            Object.DestroyImmediate(spawnPoint.gameObject);
            Object.DestroyImmediate(spawner.gameObject);

            foreach (var spawnedObject in spawnedObjects)
            {
                Object.DestroyImmediate(spawnedObject);
            }
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
            SpawnerTestUtils.ConfigureSpawner(spawner, prefab, spawnPoints);

            var spawnedObjects = spawner.SpawnCollection(objectsCountToSpawn);

            for (var i = 0; i < spawnedObjects.Count; i++)
            {
                var spawnPoint = spawnPoints[i % spawnPoints.Length];
                Assert.AreEqual(spawnPoint.position, spawnedObjects[i].transform.position);
            }

            Object.DestroyImmediate(prefab.gameObject);
            Object.DestroyImmediate(spawnPoint1.gameObject);
            Object.DestroyImmediate(spawnPoint2.gameObject);
            Object.DestroyImmediate(spawner.gameObject);

            foreach (var spawnedObject in spawnedObjects)
            {
                Object.DestroyImmediate(spawnedObject);
            }
        }
    }
}