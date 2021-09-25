using UnityEngine;
using UnityEngine.UI;

namespace VRTactics.UI
{
    [RequireComponent(typeof(Image))]
    public class FilledIndicator : MonoBehaviour
    {
        [SerializeField]
        private float defaultValue;

        private Image _image;

        public float IndicatorValue
        {
            set => _image.fillAmount = Mathf.Clamp01(value);
        }

        private void Awake()
        {
            _image = GetComponent<Image>();
            IndicatorValue = defaultValue;
        }
    }
}