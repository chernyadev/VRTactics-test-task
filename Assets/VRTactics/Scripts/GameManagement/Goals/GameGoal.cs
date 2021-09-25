using UnityEngine;
using UnityEngine.Events;

namespace VRTactics.GameManagement.Goals
{
    public class GameGoal : ScriptableObject
    {
        [SerializeField]
        private bool initialState;
        [SerializeField]
        private bool finishGameAfterStateChange;


        private readonly UnityEvent _onGameFinishRequest = new UnityEvent();
        private bool _state;
        public bool State
        {
            get => _state;
            set
            {
                if (_state == value) return;
                _state = value;
                if (finishGameAfterStateChange) _onGameFinishRequest?.Invoke();
            }
        }

        public void Init(UnityAction callback)
        {
            ResetState();
            _onGameFinishRequest.AddListener(callback);
        }

        public void Deinit()
        {
            ResetState();
            _onGameFinishRequest.RemoveAllListeners();
        }

        private void ResetState()
        {
            _state = initialState;
        }
    }
}