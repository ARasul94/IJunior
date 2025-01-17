using System;
using UnityEngine;

namespace HealthPackage.Scripts.Behaviours
{
    public class Health : MonoBehaviour
    {
        private const int Min = 0;
        
        [SerializeField] private int _max = 100;
    
        private float _current;

        public event Action Died;
        public event Action Changed;
        public float Current => _current;
        public float Max => _max;
        public bool IsAlive => Mathf.Approximately(_current, Min) == false;

        private void Awake()
        {
            SetCurrent(_max);
        }

        public bool IsNeedHeal()
        {
            return Mathf.Approximately(_current, _max) == false;
        }

        public void TakeHeal(float amount)
        {
            if (amount < 0)
                return;

            SetCurrent(Math.Clamp(_current + amount, Min, _max));
        }

        public void TakeDamage(float amount)
        {
            if (amount < 0)
                return;

            SetCurrent(Math.Clamp(_current - amount, Min, _max));
        
            if (_current <= Min)
                Died?.Invoke();
        }

        private void SetCurrent(float health)
        {
            _current = health;
            Changed?.Invoke();
        }
    }
}