using UnityEngine.Events;

namespace VRTactics.Characters
{
    public interface IAttackable
    {
        public bool IsAttacked { get; }

        public UnityEvent OnAttacked { get; }

        public void Attack();
    }
}