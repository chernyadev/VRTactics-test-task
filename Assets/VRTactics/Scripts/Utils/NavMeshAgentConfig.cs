using UnityEngine;
using UnityEngine.AI;

namespace VRTactics.Utils
{
    [CreateAssetMenu(menuName = "SO/NavMesh Agent Config", fileName = "NavMeshAgentConfig")]
    public class NavMeshAgentConfig : ScriptableObject
    {
        [SerializeField]
        private float speed = 2.0f;
        [SerializeField]
        private float angularSpeed = 120.0f;
        [SerializeField]
        private float acceleration = 8.0f;
        [SerializeField]
        private float stoppingDistance = 0.5f;

        public void Apply(NavMeshAgent agent)
        {
            agent.speed = speed;
            agent.angularSpeed = angularSpeed;
            agent.acceleration = acceleration;
            agent.stoppingDistance = stoppingDistance;
        }
    }
}