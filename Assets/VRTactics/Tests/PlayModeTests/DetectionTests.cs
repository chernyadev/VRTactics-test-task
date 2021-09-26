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
        public IEnumerator Enemy_detected_when_looking()
        {
            var detector = new GameObject("Detector").AddComponent<EnemyDetector>();
            DetectionTestUtils.ConfigureEnemyDetector(detector, ~0, detector.transform);

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
        public IEnumerator Enemy_not_detected_when_looking_away()
        {
            var detector = new GameObject("Detector").AddComponent<EnemyDetector>();
            DetectionTestUtils.ConfigureEnemyDetector(detector, ~0, detector.transform);
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

        [UnityTest]
        public IEnumerator Enemy_fully_detected_after_looking_for_detection_time()
        {
            const float detectionTime = 0.5f;

            var detector = new GameObject("Detector").AddComponent<EnemyDetector>();
            DetectionTestUtils.ConfigureEnemyDetector(detector, ~0, detector.transform);

            var detectable = new GameObject("Detectable").AddComponent<DetectionController>();
            DetectionTestUtils.ConfigureDetectionController(detectable, detectionTime);
            var fullyDetected = false;

            detectable.onDetected.AddListener(() => fullyDetected = true);
            detectable.transform.position = new Vector3(0, 0, 10);
            detectable.gameObject.AddComponent<SphereCollider>();

            yield return new WaitForSeconds(detectionTime);
            yield return new WaitForFixedUpdate();

            Assert.IsTrue(fullyDetected);

            Object.Destroy(detectable.gameObject);
            Object.Destroy(detector.gameObject);
        }

        [UnityTest]
        public IEnumerator Enemy_not_fully_detected_before_looking_for_detection_time()
        {
            const float detectionTime = 0.5f;

            var detector = new GameObject("Detector").AddComponent<EnemyDetector>();
            DetectionTestUtils.ConfigureEnemyDetector(detector, ~0, detector.transform);

            var detectable = new GameObject("Detectable").AddComponent<DetectionController>();
            DetectionTestUtils.ConfigureDetectionController(detectable, detectionTime);
            var fullyDetected = false;

            detectable.onDetected.AddListener(() => fullyDetected = true);
            detectable.transform.position = new Vector3(0, 0, 10);
            detectable.gameObject.AddComponent<SphereCollider>();

            yield return new WaitForSeconds(detectionTime / 2);

            Assert.IsFalse(fullyDetected);

            Object.Destroy(detectable.gameObject);
            Object.Destroy(detector.gameObject);
        }
    }
}