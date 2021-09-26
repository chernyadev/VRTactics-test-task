using NUnit.Framework;
using TMPro;
using UnityEditor;
using UnityEngine;
using VRTactics.GameManagement;
using VRTactics.UI;

namespace VRTactics.EditModeTests
{
    public class UiStatisticsTests
    {
        [Test]
        public void EnemyDataDisplayedCorrectly()
        {
            const string pathToPanelPrefab = "Assets/VRTactics/Prefabs/UI/EnemyStatusPanel.prefab";

            const string playerName = "ABC";
            const DetectionsStatus status = DetectionsStatus.Found;
            const int id = 42;

            var panelPrefab = (GameObject) AssetDatabase.LoadAssetAtPath(pathToPanelPrefab, typeof(GameObject));
            var panel = Object.Instantiate(panelPrefab).GetComponent<EnemyStatisticsPanel>();
            var data = new DetectionData(playerName, status);
            panel.Show(data, id);

            var serializedPanel = new SerializedObject(panel);

            var idLabel = (TMP_Text) serializedPanel.FindProperty("idLabel").objectReferenceValue;
            var nameLabel = (TMP_Text) serializedPanel.FindProperty("nameLabel").objectReferenceValue;
            var statusLabel = (TMP_Text) serializedPanel.FindProperty("statusLabel").objectReferenceValue;

            Assert.AreEqual(id.ToString(), idLabel.text);
            Assert.AreEqual(playerName, nameLabel.text);
            Assert.AreEqual(status.GetLabelText(), statusLabel.text);

            Object.DestroyImmediate(panel.gameObject);
        }
    }
}