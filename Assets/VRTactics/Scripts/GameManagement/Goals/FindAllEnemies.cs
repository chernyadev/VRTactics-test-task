using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRTactics.Characters;

namespace VRTactics.GameManagement.Goals
{
    [CreateAssetMenu(menuName = "SO/Goals/Find All Enemies", fileName = "FindAllEnemies")]
    public class FindAllEnemies : GameGoal
    {
        public List<IDetectable> Enemies { private get; set; }

        private void DetectionHandler()
        {
            if (Enemies.All(e => e.IsDetected)) State = true;
        }
    }
}