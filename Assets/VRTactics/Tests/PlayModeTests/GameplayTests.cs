using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using VRTactics.GameManagement;

namespace VRTactics.PlayModeTests
{
    public class GameplayTests
    {
        [UnityTest]
        [LoadScene("Assets/VRTactics/Scenes/GameplayScene.unity")]
        public IEnumerator Game_ends_when_player_reaches_destination()
        {
            yield return new WaitForSeconds(0.1f);

            var playerController = Object.FindObjectOfType<CharacterController>();
            var gameManager = Object.FindObjectOfType<GameManager>();
            var destination = Object.FindObjectOfType<DestinationTrigger>();

            var gameFinished = false;
            gameManager.onGameFinished.AddListener(_ => gameFinished = true);

            playerController.enabled = false;
            playerController.transform.position = destination.transform.position;
            playerController.enabled = true;

            yield return new WaitForFixedUpdate();

            Assert.IsTrue(gameFinished);
        }
        
        [UnityTest]
        [LoadScene("Assets/VRTactics/Scenes/GameplayScene.unity")]
        public IEnumerator Game_failed_when_player_reaches_destination_and_doesnt_find_enemies()
        {
            yield return new WaitForSeconds(0.1f);

            var playerController = Object.FindObjectOfType<CharacterController>();
            var gameManager = Object.FindObjectOfType<GameManager>();
            var destination = Object.FindObjectOfType<DestinationTrigger>();

            var gameResultsData = new GameResultsData();
            gameManager.onGameFinished.AddListener(result => gameResultsData = result);

            playerController.enabled = false;
            playerController.transform.position = destination.transform.position;
            playerController.enabled = true;

            yield return new WaitForFixedUpdate();

            Assert.AreEqual(OverallGameResult.Defeat, gameResultsData.OverallResult);
        }
    }
}