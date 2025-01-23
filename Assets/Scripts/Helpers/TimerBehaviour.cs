using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Helpers
{
    public class TimerBehaviour : MonoBehaviour
    {
        [SerializeField][Min(0.1f)] private float _min = 2;
        [SerializeField][Min(0.2f)] private float _max = 5;
        [SerializeField][Min(0.01f)] private float _updatePeriod = 0.1f;

        public event Action<float> OnTimeChanged;
        public event Action OnTimerStated;
        public event Action OnTimerEnded;

        public float Left { get; private set; }
        public float Max => _maxTime;
        public bool Finished => Left == 0;
        
        private float _maxTime;

        public void StartTimer()
        {
            _maxTime = Random.Range(_min, _max);
            Left = _maxTime;
            StartCoroutine(TimerCoroutine());
        }

        private IEnumerator TimerCoroutine()
        {
            WaitForSeconds waiter = new WaitForSeconds(_updatePeriod);
            OnTimerStated?.Invoke();

            while (Left > 0)
            {
                Left = Mathf.Clamp(Left - _updatePeriod, 0, _maxTime);
                OnTimeChanged?.Invoke(Left);
                
                yield return waiter;
            }
            
            OnTimerEnded?.Invoke();
        }
    }
}