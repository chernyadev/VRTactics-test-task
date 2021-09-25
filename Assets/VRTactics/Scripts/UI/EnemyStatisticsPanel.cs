using TMPro;
using UnityEngine;
using VRTactics.GameManagement;

namespace VRTactics.UI
{
    public class EnemyStatisticsPanel : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text idLabel;
        [SerializeField]
        private TMP_Text nameLabel;
        [SerializeField]
        private TMP_Text statusLabel;

        [Space]
        [SerializeField]
        private Color foundStatusColor;
        [SerializeField]
        private Color notFoundStatusColor;

        public void Show(DetectionData data, int id)
        {
            idLabel.text = id.ToString();

            nameLabel.text = data.Name;

            statusLabel.text = data.Status.GetLabelText();
            statusLabel.color = data.Status == DetectionsStatus.Found ? foundStatusColor : notFoundStatusColor;
        }
    }
}