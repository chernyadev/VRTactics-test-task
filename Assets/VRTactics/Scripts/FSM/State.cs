using System;
using UnityEngine;

namespace VRTactics.FSM
{
    [Serializable]
    public abstract class State : ScriptableObject
    {
        protected StateMachine Machine;
        protected State NextState;

        public virtual void Init(StateMachine stateMachine, State nexState)
        {
            Machine = stateMachine;
            NextState = nexState;
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
        }

        public virtual void OnUpdate()
        {
        }
    }
}