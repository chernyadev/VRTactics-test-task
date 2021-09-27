using UnityEngine;
using VRTactics.FSM;

namespace VRTactics.Characters.FSM
{
    [CreateAssetMenu(menuName = "SO/FSM/States/Idle State", fileName = "IdleState")]
    public class IdleState : State
    {
        [SerializeField]
        private float minAttackDelay = 5.0f;
        [SerializeField]
        private float maxAttackDelay = 120.0f;

        private float _attackDelay;
        private float _startTime;

        public override void OnEnter()
        {
            _startTime = Time.time;
            _attackDelay = Random.Range(minAttackDelay, maxAttackDelay);
        }

        public override void OnUpdate()
        {
            if (ShouldAttack())
            {
                Machine.Transition(NextState);
            }
        }

        private bool ShouldAttack()
        {
            return Time.time - _startTime >= _attackDelay;
        }
    }
}