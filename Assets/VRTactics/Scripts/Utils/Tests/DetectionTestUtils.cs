using UnityEditor;
using UnityEngine;
using VRTactics.Characters;

namespace VRTactics.Utils.Tests
{
    public static class DetectionTestUtils
    {
        public static void ConfigureEnemyDetector(EnemyDetector detector, LayerMask mask, Transform raycastRoot)
        {
            var serializedDetector = new SerializedObject(detector);

            var maskProp = serializedDetector.FindProperty("detectionMask");
            var rootProp = serializedDetector.FindProperty("raycastRoot");

            maskProp.intValue = mask;
            rootProp.objectReferenceValue = raycastRoot;

            serializedDetector.ApplyModifiedProperties();
        }

        public static void ConfigureDetectionController(DetectionController detectionController, float detectionTime)
        {
            var serializedController = new SerializedObject(detectionController);

            var timeToDetectProp = serializedController.FindProperty("timeToDetect");

            timeToDetectProp.floatValue = detectionTime;

            serializedController.ApplyModifiedProperties();
        }
    }
}