using UnityEngine;
using UnityEngine.AI;
using VRTactics.FSM;

namespace VRTactics.Characters.FSM
{
    [CreateAssetMenu(menuName = "SO/FSM/States/Return To Home State", fileName = "ReturnToHomeState")]
    public class ReturnToHomeState : NavMeshAgentState
    {
        private Vector3 _homePosition;

        public override void Init(NavMeshAgent agent, StateMachine stateMachine, State nextState)
        {
            base.Init(agent, stateMachine, nextState);
            _homePosition = agent.transform.position;
        }

        public override void OnUpdate()
        {
            if (IsAgentAvailable)
            {
                Agent.destination = _homePosition;
            }
        }
    }
}