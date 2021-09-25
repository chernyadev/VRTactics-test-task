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
        [Range(0, MAX_ENEMIES_COUNT)]
        private int enemiesCount = 4;

        [Space]
        [SerializeField]
        private List<GameGoal> goals;

        private List<IDetectable> _enemies;

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
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

            // State goals
            var findAllEnemiesGoal = ScriptableObject.CreateInstance<FindAllEnemies>();
            findAllEnemiesGoal.Enemies = _enemies;
            goals.Add(findAllEnemiesGoal);

            foreach (var goal in goals) goal.Init(FinishGame);

            // Init
            onGameStarted.Invoke();
        }

        public void FinishGame()
        {
            foreach (var goal in goals) goal.Deinit();

            enemiesSpawner.Clean();
            var results = new GameResultsData(GetOverallResult(), GetEnemiesData());
            onGameFinished.Invoke(results);
        }

        private OverallGameResult GetOverallResult()
        {
            return goals.All(g => g.State) ? OverallGameResult.Victory : OverallGameResult.Defeat;
        }

        private List<DetectionData> GetEnemiesData()
        {
            return _enemies.Select(e => e.DetectionData).ToList();
        }
    }
}