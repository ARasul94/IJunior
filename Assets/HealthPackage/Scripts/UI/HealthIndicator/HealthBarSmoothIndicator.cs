using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HealthPackage.Scripts.UI.HealthIndicator
{
    public class HealthBarSmoothIndicator : HealthIndicatorBase
    {
        [SerializeField] private Image _fillImage;
        [SerializeField][Min(0.01f)] private float _delta = 0.01f;
        [SerializeField][Min(0.01f)] private float _updateSpeed = 0.01f;

        private Coroutine _updateCoroutine;
        
        protected override void OnHealthChanged()
        {
            if (_updateCoroutine != null)
                StopCoroutine(_updateCoroutine);

            _updateCoroutine = StartCoroutine(IncreaseCoroutine());
        }

        private IEnumerator IncreaseCoroutine()
        {
            WaitForSeconds waiter = new WaitForSeconds(_updateSpeed);
            float currentFilling = _fillImage.fillAmount;
            float targetFilling = _health.Current / _health.Max;
            
            while (Mathf.Approximately(currentFilling, targetFilling) == false)
            {
                currentFilling = Mathf.MoveTowards(currentFilling, targetFilling, _delta);
                _fillImage.fillAmount = currentFilling;
                yield return waiter;
            }

            _updateCoroutine = null;
        }
    }
}