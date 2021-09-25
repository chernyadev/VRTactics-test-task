using UnityEngine;
using UnityEngine.AI;
using VRTactics.FSM;

namespace VRTactics.Characters.FSM
{
    public class EnemyStateMachine : StateMachine
    {
        [SerializeField]
        protected NavMeshAgent agent;

        [Header("States")]
        [SerializeField]
        protected IdleState idleState;
        [SerializeField]
        protected AttackState attackState;
        [SerializeField]
        protected ReturnToHomeState returnToHome;

        private Transform _target;

        public void Init(Transform target)
        {
            _target = target;

            idleState = Instantiate(idleState);
            attackState = Instantiate(attackState);
            returnToHome = Instantiate(returnToHome);

            idleState.Init(this, attackState);
            attackState.Init(_target, agent, this, returnToHome);
            returnToHome.Init(agent, this, idleState);

            Transition(idleState);
        }

        public void CancelAttack()
        {
            Transition(returnToHome);
        }
    }
}