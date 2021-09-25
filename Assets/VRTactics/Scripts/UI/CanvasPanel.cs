using UnityEngine;

namespace VRTactics.UI
{
    public class CanvasPanel : MonoBehaviour
    {
        [SerializeField]
        private Canvas canvas;

        public void Show()
        {
            canvas.enabled = true;
        }

        public void Hide()
        {
            canvas.enabled = false;
        }
    }
}