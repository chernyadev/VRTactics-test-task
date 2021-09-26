using UnityEditor;
using UnityEngine;
using VRTactics.Characters;

namespace VRTactics.Utils.Tests
{
    public static class EnemyDetectorTestUtils
    {
        public static void ConfigureEnemyDetector(EnemyDetector detector, LayerMask mask, Transform raycastRoot)
        {
            var serializedSpawner = new SerializedObject(detector);

            var maskProp = serializedSpawner.FindProperty("detectionMask");
            var rootProp = serializedSpawner.FindProperty("raycastRoot");

            maskProp.intValue = mask;
            rootProp.objectReferenceValue = raycastRoot;

            serializedSpawner.ApplyModifiedProperties();
        }
    }
}