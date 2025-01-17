using System;
using System.Collections;
using UnityEngine;

namespace Helpers
{
    public class TimerBehaviour : MonoBehaviour
    {
        [SerializeField][Min(0.1f)] private float _time = 6;
        [SerializeField][Min(0.01f)] private float _updatePeriod = 0.1f;

        public event Action<float> OnTimeChanged;
        public event Action OnTimerStated;
        public event Action OnTimerEnded;

        public float Left { get; private set; }
        public float Max => _time;
        public bool Finished => Left == 0;

        public void StartTimer()
        {
            Left = Max;
            StartCoroutine(TimerCoroutine());
        }

        private IEnumerator TimerCoroutine()
        {
            WaitForSeconds waiter = new WaitForSeconds(_updatePeriod);
            OnTimerStated?.Invoke();

            while (Left > 0)
            {
                Left = Mathf.Clamp(Left - _updatePeriod, 0, _time);
                OnTimeChanged?.Invoke(Left);
                yield return waiter;
            }
            
            OnTimerEnded?.Invoke();
        }
    }
}