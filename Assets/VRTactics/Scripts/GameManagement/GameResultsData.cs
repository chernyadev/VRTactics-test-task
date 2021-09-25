using System.Collections.Generic;

namespace VRTactics.GameManagement
{
    public readonly struct GameResultsData
    {
        public readonly OverallGameResult OverallResult;
        public readonly List<DetectionData> EnemyStatistics;

        public GameResultsData(OverallGameResult overallResult, List<DetectionData> enemyStatistics)
        {
            OverallResult = overallResult;
            EnemyStatistics = enemyStatistics;
        }
    }
}