using UnityEngine;
using UnityEngine.Events;
using VRTactics.GameManagement;

namespace VRTactics.Characters
{
    public class DetectionController : MonoBehaviour, IDetectable
    {
        [Header("Callbacks")]
        public UnityEvent<float> onDetectionStateChanged = new UnityEvent<float>();
        public UnityEvent onDetected;

        [Space]
        [SerializeField]
        private float timeToDetect = 3.0f;

        private float _detectionState;

        private DetectionsStatus Status => IsDetected ? DetectionsStatus.Found : DetectionsStatus.NotFound;
        private float DetectionState
        {
            get => _detectionState;
            set
            {
                if (_detectionState.Equals(value))
                {
                    return;
                }

                _detectionState = Mathf.Clamp01(value);
                onDetectionStateChanged.Invoke(_detectionState);
                if (IsDetected)
                {
                    onDetected.Invoke();
                }
            }
        }

        public bool IsDetected => DetectionState >= 1.0f;
        public DetectionData DetectionData => new DetectionData(name, Status);

        public void Detect(float detectionDelta)
        {
            DetectionState += detectionDelta / timeToDetect;
        }
    }
}