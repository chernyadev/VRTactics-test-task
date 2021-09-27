using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using VRTactics.Characters;
using VRTactics.Characters.FSM;
using VRTactics.GameManagement;

namespace VRTactics.PlayModeTests
{
    public class GameplayTests
    {
        private DestinationTrigger _destination;
        private List<DetectionController> _enemies;
        private GameManager _gameManager;
        private CharacterController _playerController;

        [UnityTest]
        [LoadScene("Assets/VRTactics/Scenes/GameplayScene.unity")]
        public IEnumerator Game_ends_when_player_reaches_destination()
        {
            yield return AssignGameplayReferences();

            var gameFinished = false;
            _gameManager.onGameFinished.AddListener(_ => gameFinished = true);

            TeleportPlayer(_destination.transform.position);

            yield return new WaitForFixedUpdate();

            Assert.IsTrue(gameFinished);
        }

        [UnityTest]
        [LoadScene("Assets/VRTactics/Scenes/GameplayScene.unity")]
        public IEnumerator Game_failed_if_player_reaches_destination_and_does_not_find_enemies()
        {
            yield return AssignGameplayReferences();

            var gameResultsData = new GameResultsData();
            _gameManager.onGameFinished.AddListener(result => gameResultsData = result);

            TeleportPlayer(_destination.transform.position);

            yield return new WaitForFixedUpdate();

            Assert.AreEqual(OverallGameResult.Defeat, gameResultsData.OverallResult);
        }

        [UnityTest]
        [LoadScene("Assets/VRTactics/Scenes/GameplayScene.unity")]
        public IEnumerator Game_failed_if_player_is_attacked()
        {
            yield return AssignGameplayReferences();

            var gameResultsData = new GameResultsData();
            _gameManager.onGameFinished.AddListener(result => gameResultsData = result);

            foreach (var enemy in _enemies)
            {
                var fsm = enemy.GetComponent<EnemyStateMachine>();
                var serializedFsm = new SerializedObject(fsm);

                var idleState = (IdleState) serializedFsm.FindProperty("idleState").objectReferenceValue;
                var serializedState = new SerializedObject(idleState);
                serializedState.FindProperty("minAttackDelay").floatValue = 0;
                serializedState.FindProperty("maxAttackDelay").floatValue = 0;

                serializedState.ApplyModifiedProperties();
                serializedFsm.ApplyModifiedProperties();

                idleState.OnEnter();
            }

            var targetEnemyTransform = _enemies.First().transform;
            TeleportPlayer(targetEnemyTransform.position + targetEnemyTransform.forward * 1.0f);

            yield return new WaitForSeconds(0.1f);

            Assert.AreEqual(OverallGameResult.Defeat, gameResultsData.OverallResult);
        }

        private IEnumerator AssignGameplayReferences()
        {
            yield return new WaitForSeconds(0.1f);

            _playerController = Object.FindObjectOfType<CharacterController>();
            _gameManager = Object.FindObjectOfType<GameManager>();
            _destination = Object.FindObjectOfType<DestinationTrigger>();
            _enemies = Object.FindObjectsOfType<DetectionController>().ToList();
        }

        private void TeleportPlayer(Vector3 targetPosition, Quaternion targetRotation = default)
        {
            _playerController.enabled = false;
            _playerController.transform.SetPositionAndRotation(targetPosition, targetRotation);
            _playerController.enabled = true;
        }
    }
}