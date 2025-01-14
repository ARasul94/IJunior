using UnityEngine;
using UnityEngine.UI;

namespace UI.HealthIndicator
{
    public class HealthBarIndicator : HealthIndicatorBase
    {
        [SerializeField] private Image _fillImage;
        
        protected override void OnHealthChanged()
        {
            _fillImage.fillAmount = _health.Current / _health.Max;
        }
    }
}