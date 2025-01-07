using System;
using UnityEngine;

namespace Behaviours
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _max = 100;
    
        private float _current;

        public event Action Died;
        public event Action Changed;
        public float Current => _current;
        public float Max => _max;
    

        private void Awake()
        {
            _current = _max;
        }

        public bool IsNeedHeal()
        {
            return Mathf.Approximately(_current, _max) == false;
        }

        public void TakeHeal(float amount)
        {
            if (amount < 0)
                return;
            
            _current += amount;
            _current = Math.Min(_current, _max);
            Changed?.Invoke();
        }

        public void TakeDamage(float amount)
        {
            if (amount < 0)
                return;
            
            _current -= amount;

            _current = Math.Max(_current, 0);
            Changed?.Invoke();
        
            if (_current <= 0)
                Died?.Invoke();
        }
    }
}