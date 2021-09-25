using UnityEngine;
using VRTactics.GameManagement;

namespace VRTactics.UI
{
    public class GameUiController : MonoBehaviour
    {
        [SerializeField]
        private CanvasPanel gameplayPanel;
        [SerializeField]
        private GameResultsPanel resultsPanel;

        private void Start()
        {
            ShowGameplayUi();
        }

        public void ShowGameplayUi()
        {
            gameplayPanel.Show();
            resultsPanel.Hide();
        }

        public void ShowResultsUi(GameResultsData results)
        {
            gameplayPanel.Hide();
            resultsPanel.Show(results);
        }
    }
}