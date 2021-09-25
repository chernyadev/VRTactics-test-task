using UnityEngine;
using UnityEngine.AI;
using VRTactics.FSM;
using VRTactics.Utils;

namespace VRTactics.Characters.FSM
{
    public class NavMeshAgentState : State
    {
        [SerializeField]
        private NavMeshAgentConfig agentConfig;
        protected NavMeshAgent Agent;

        protected bool IsAgentAvailable => Agent.isActiveAndEnabled && Agent.isOnNavMesh;

        public virtual void Init(NavMeshAgent agent, StateMachine stateMachine, State nextState)
        {
            Init(stateMachine, nextState);
            Agent = agent;
            agentConfig.Apply(Agent);
        }
    }
}