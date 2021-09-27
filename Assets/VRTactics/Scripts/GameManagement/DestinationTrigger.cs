using UnityEngine;
using UnityEngine.Events;

namespace VRTactics.GameManagement
{
    public class DestinationTrigger : MonoBehaviour
    {
        [Space]
        [SerializeField]
        public UnityEvent onDestinationReached;

        [SerializeField]
        private LayerMask detectionMask;

        public bool IsReached { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsLayerMatchesMask(other))
            {
                return;
            }

            IsReached = true;
            onDestinationReached.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!IsLayerMatchesMask(other))
            {
                return;
            }

            IsReached = false;
        }

        private bool IsLayerMatchesMask(Component other)
        {
            return detectionMask == (detectionMask | (1 << other.gameObject.layer));
        }
    }
}