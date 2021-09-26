using UnityEngine.Events;
using VRTactics.GameManagement;

namespace VRTactics.Characters
{
    public interface IDetectable
    {
        public bool IsDetected { get; }
        public DetectionData DetectionData { get; }
        public void Detect(float detectionDelta);
    }
}