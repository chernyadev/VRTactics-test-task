using System.Collections.Generic;
using UnityEngine;
using VRTactics.GameManagement;

namespace VRTactics.UI
{
    public class EnemyStatisticsList : MonoBehaviour
    {
        [SerializeField]
        private EnemyStatisticsPanel panelPrefab;
        [SerializeField]
        private RectTransform listRoot;

        private List<EnemyStatisticsPanel> _panels = new List<EnemyStatisticsPanel>();

        public void Show(List<DetectionData> statistics)
        {
            Clean();

            for (var i = 0; i < statistics.Count; i++)
            {
                var panel = Instantiate(panelPrefab, listRoot);
                panel.Show(statistics[i], i + 1);
                _panels.Add(panel);
            }
        }

        private void Clean()
        {
            foreach (var t in _panels) Destroy(t.gameObject);

            _panels = new List<EnemyStatisticsPanel>();
        }
    }
}