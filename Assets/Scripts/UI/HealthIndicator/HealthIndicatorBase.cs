using System;
using Behaviours;
using UnityEngine;

namespace UI.HealthIndicator
{
    public abstract class HealthIndicatorBase : MonoBehaviour
    {
        [SerializeField] protected Health _health;

        protected virtual void OnEnable()
        {
            _health.Changed += OnHealthChanged;
        }

        protected virtual void OnDisable()
        {
            _health.Changed -= OnHealthChanged;
        }

        protected abstract void OnHealthChanged();
    }
}