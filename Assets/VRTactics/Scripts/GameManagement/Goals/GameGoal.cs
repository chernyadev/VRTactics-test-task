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
        private bool _isAchieved;

        private Action _onGameFinishRequestCallback;

        public bool IsAchieved
        {
            get => _isAchieved;
            set
            {
                if (_isAchieved == value)
                {
                    return;
                }

                _isAchieved = value;
                if (finishGameAfterStateChange)
                {
                    _onGameFinishRequestCallback?.Invoke();
                }
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
            _isAchieved = initialState;
        }
    }
}