using TMPro;
using UnityEngine;

namespace UI.HealthIndicator
{
    public class HealthTextIndicator : HealthIndicatorBase
    {
        [SerializeField] private TextMeshProUGUI _healthField;
        
        protected override void OnHealthChanged()
        {
            _healthField.text = $"{_health.Current:N0}/{_health.Max:N0}";
        }
    }
}