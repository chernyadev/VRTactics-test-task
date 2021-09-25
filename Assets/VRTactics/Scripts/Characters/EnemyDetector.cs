using UnityEngine;

namespace VRTactics.Characters
{
    public class EnemyDetector : MonoBehaviour
    {
        [SerializeField]
        private LayerMask detectionMask;
        [SerializeField]
        private float detectionDistance = 20;
        [SerializeField]
        private Transform raycastRoot;

        private void FixedUpdate()
        {
            var ray = new Ray(raycastRoot.position, raycastRoot.forward);
            if (!Physics.Raycast(ray, out var hit, detectionDistance, detectionMask)) return;

            var detectable = hit.transform.GetComponentInChildren<IDetectable>();
            detectable?.Detect(Time.fixedDeltaTime);
        }
    }
}