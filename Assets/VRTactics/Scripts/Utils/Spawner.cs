using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VRTactics.Utils
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private Transform[] spawnPoints;

        private readonly List<GameObject> instatiatedPrefabs = new List<GameObject>();

        public GameObject SpawnSingle()
        {
            return SpawnPrefab(spawnPoints.First());
        }

        public List<GameObject> SpawnCollection(int count = 1)
        {
            var instances = new List<GameObject>();

            for (var spawned = 0; spawned < count;)
                foreach (var point in spawnPoints)
                {
                    instances.Add(SpawnPrefab(point));
                    spawned++;
                    if (spawned >= count) break;
                }

            return instances;
        }

        public void Clean()
        {
            foreach (var prefab in instatiatedPrefabs) Destroy(prefab);
        }

        private GameObject SpawnPrefab(Transform spawnPoint)
        {
            var instance = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            instatiatedPrefabs.Add(instance);

            return instance;
        }
    }
}