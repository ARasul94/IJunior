using HealthPackage.Scripts.Behaviours;
using UnityEngine;

namespace HealthPackage.Scripts.UI.HealthIndicator
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