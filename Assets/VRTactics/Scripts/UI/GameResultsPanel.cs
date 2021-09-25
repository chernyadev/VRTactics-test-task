using TMPro;
using UnityEngine;
using VRTactics.GameManagement;
using VRTactics.Utils;

namespace VRTactics.UI
{
    public class GameResultsPanel : CanvasPanel
    {
        [SerializeField]
        private TMP_Text gameStatusLabel;
        [SerializeField]
        private EnemyStatisticsList statisticsList;

        public void Show(GameResultsData resultsData)
        {
            gameStatusLabel.text = resultsData.OverallResult.GetLabelText();
            statisticsList.Show(resultsData.EnemyStatistics);
            base.Show();
        }

        public void Restart()
        {
            SceneLoader.Reload();
        }
    }
}