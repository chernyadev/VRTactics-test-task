using System;
using UnityEngine;

namespace VRTactics.GameManagement.Goals
{
    public class GameGoal : ScriptableObject
    {
        [SerializeField]
        private bool initialState;
        [SerializeField]
        private bool finishGameAfterStateChange;

        private Action _onGameFinishRequestCallback;
        private bool _state;
        public bool State
        {
            get => _state;
            set
            {
                if (_state == value) return;
                _state = value;
                if (finishGameAfterStateChange) _onGameFinishRequestCallback?.Invoke();
            }
        }

        public virtual void Init(Action onGameFinishRequestCallback)
        {
            ResetState();
            _onGameFinishRequestCallback = onGameFinishRequestCallback;
        }

        public virtual void Deinit()
        {
            ResetState();
            _onGameFinishRequestCallback = null;
        }

        private void ResetState()
        {
            _state = initialState;
        }
    }
}