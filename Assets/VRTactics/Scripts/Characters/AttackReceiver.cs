using UnityEngine;
using UnityEngine.Events;

namespace VRTactics.Characters
{
    public class AttackReceiver : MonoBehaviour, IAttackable
    {
        public UnityEvent onAttacked;

        public bool IsAttacked { get; private set; }
        public UnityEvent OnAttacked => onAttacked;

        public void Attack()
        {
            IsAttacked = true;
            onAttacked?.Invoke();
        }
    }
}