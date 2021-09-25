using UnityEngine;

namespace VRTactics.FSM
{
    public class StateMachine : MonoBehaviour
    {
        private State _currentState;

        private void Update()
        {
            if (_currentState != null) _currentState.OnUpdate();
        }

        public void Transition(State nextState)
        {
            if (_currentState) _currentState.OnExit();
            _currentState = nextState;
            _currentState.OnEnter();
        }
    }
}