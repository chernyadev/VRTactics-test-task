using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRTactics.Characters;

namespace VRTactics.GameManagement.Goals
{
    [CreateAssetMenu(menuName = "SO/Goals/Find All Enemies", fileName = "FindAllEnemies")]
    public class FindAllEnemies : GameGoal
    {
        private List<DetectionController> _enemies;

        public override void Init(Action onGameFinishRequestCallback)
        {
            base.Init(onGameFinishRequestCallback);

            _enemies = FindObjectsOfType<DetectionController>().ToList();
            
            foreach (var enemy in _enemies)
            {
                enemy.onDetected.AddListener(DetectionHandler);
            }

            DetectionHandler();
        }

        public override void Deinit()
        {
            foreach (var enemy in _enemies)
            {
                enemy.onDetected.RemoveListener(DetectionHandler);
            }

            _enemies.Clear();

            base.Deinit();
        }

        private void DetectionHandler()
        {
            if (_enemies.All(e => e.IsDetected))
            {
                IsAchieved = true;
            }
        }
    }
}