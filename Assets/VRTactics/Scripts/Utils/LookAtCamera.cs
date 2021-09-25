using UnityEngine;

namespace VRTactics.Utils
{
    public class LookAtCamera : MonoBehaviour
    {
        private Transform _cameraTransform;
        private Transform _transform;

        private void Start()
        {
            _transform = transform;
            _cameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            _transform.LookAt(_cameraTransform);
            _transform.rotation = Quaternion.LookRotation(_cameraTransform.forward);
        }
    }
}