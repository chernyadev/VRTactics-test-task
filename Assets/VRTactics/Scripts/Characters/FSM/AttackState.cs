using UnityEngine;
using UnityEngine.AI;
using VRTactics.FSM;

namespace VRTactics.Characters.FSM
{
    [CreateAssetMenu(menuName = "SO/FSM/States/Attack State", fileName = "AttackState")]
    public class AttackState : NavMeshAgentState
    {
        [SerializeField]
        private float attackDistance = 1.0f;
        [SerializeField]
        private LayerMask attackMask;
        private readonly Collider[] _results = new Collider[5];

        private Transform _target;

        public void Init(Transform target, NavMeshAgent agent, StateMachine stateMachine, State nextState)
        {
            Init(agent, stateMachine, nextState);
            _target = target;
        }

        public override void OnUpdate()
        {
            TryAttackPlayer();
            if (IsAgentAvailable)
            {
                Agent.destination = _target.position;
            }
        }

        private void TryAttackPlayer()
        {
            if (Agent.remainingDistance > attackDistance)
            {
                return;
            }

            var collidersCount = Physics.OverlapSphereNonAlloc(Agent.transform.position, attackDistance, _results, attackMask);
            if (collidersCount <= 0)
            {
                return;
            }

            for (var i = 0; i < collidersCount; i++)
            {
                var collider = _results[i];
                var player = collider.GetComponentInChildren<IAttackable>();
                player?.Attack();
            }
        }
    }
}