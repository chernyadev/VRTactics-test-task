using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using VRTactics.Characters;
using VRTactics.Utils.Tests;

namespace VRTactics.PlayModeTests
{
    public class DetectionTests
    {
        [UnityTest]
        public IEnumerator Detectable_Detected_When_Looking_At_It()
        {
            var detector = new GameObject("Detector").AddComponent<EnemyDetector>();
            EnemyDetectorTestUtils.ConfigureEnemyDetector(detector, ~0, detector.transform);
            
            var detectable = new GameObject("Detectable").AddComponent<DetectionController>();
            var wasDetected = false;

            detectable.onDetectionStateChanged.AddListener(value => wasDetected = true);
            detectable.transform.position = new Vector3(0, 0, 10);
            detectable.gameObject.AddComponent<SphereCollider>();

            yield return new WaitForFixedUpdate();
            
            Assert.IsTrue(wasDetected);

            Object.Destroy(detectable.gameObject);
            Object.Destroy(detector.gameObject);
        }
        
        [UnityTest]
        public IEnumerator Detectable_Not_Detected_When_Looking_Away()
        {
            var detector = new GameObject("Detector").AddComponent<EnemyDetector>();
            EnemyDetectorTestUtils.ConfigureEnemyDetector(detector, ~0, detector.transform);
            detector.transform.forward = Vector3.back;
            
            var detectable = new GameObject("Detectable").AddComponent<DetectionController>();
            var wasDetected = false;

            detectable.onDetectionStateChanged.AddListener(value => wasDetected = true);
            detectable.transform.position = new Vector3(0, 0, 10);
            detectable.gameObject.AddComponent<SphereCollider>();

            yield return new WaitForFixedUpdate();
            
            Assert.IsFalse(wasDetected);
            
            Object.Destroy(detectable.gameObject);
            Object.Destroy(detector.gameObject);
        }
    }
}
