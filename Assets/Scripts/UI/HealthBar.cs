using Behaviours;
using TMPro;
using UnityEngine;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthField;
        [SerializeField] private Health _health;

        private void OnEnable()
        {
            _health.Changed += OnHealthChanged;
        }

        private void OnDisable()
        {
            _health.Changed -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            _healthField.text = $"{_health.Current:N0}/{_health.Max:N0}";
        }
    }
}