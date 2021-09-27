using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using VRTactics.Characters;
using VRTactics.Characters.FSM;
using VRTactics.GameManagement.Goals;
using VRTactics.Utils;

namespace VRTactics.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        private const int MIN_ENEMIES_COUNT = 1;
        private const int MAX_ENEMIES_COUNT = 100;

        [Header("Callbacks")]
        public UnityEvent onGameStarted;
        public UnityEvent<GameResultsData> onGameFinished;

        [Space]
        [Header("Spawners")]
        [SerializeField]
        private Spawner enemiesSpawner;
        [SerializeField]
        private Spawner playerSpawner;

        [Space]
        [SerializeField]
        [Range(MIN_ENEMIES_COUNT, MAX_ENEMIES_COUNT)]
        private int enemiesCount = 4;

        [Space]
        [SerializeField]
        private List<GameGoal> goals;

        private List<IDetectable> _enemies;

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            // Spawn player
            var playerInstance = playerSpawner.SpawnSingle();

            // Spawn and cache enemies
            var enemiesPrefabs = enemiesSpawner.SpawnCollection(enemiesCount);
            _enemies = new List<IDetectable>();
            foreach (var enemy in enemiesPrefabs)
            {
                enemy.GetComponent<EnemyStateMachine>().Init(playerInstance.transform);
                _enemies.Add(enemy.GetComponent<IDetectable>());
            }

            // Init goals
            foreach (var goal in goals)
            {
                goal.Init(FinishGame);
            }

            onGameStarted.Invoke();
        }

        private void FinishGame()
        {
            // Collecting game results
            var results = new GameResultsData(GetOverallResult(), GetEnemiesData());

            // Destroying spawned enemies
            enemiesSpawner.Clean();

            // Terminating goals
            foreach (var goal in goals)
            {
                goal.Deinit();
            }

            onGameFinished.Invoke(results);
        }

        private OverallGameResult GetOverallResult()
        {
            return goals.All(g => g.IsAchieved) ? OverallGameResult.Victory : OverallGameResult.Defeat;
        }

        private List<DetectionData> GetEnemiesData()
        {
            return _enemies.Select(e => e.DetectionData).ToList();
        }
    }
}