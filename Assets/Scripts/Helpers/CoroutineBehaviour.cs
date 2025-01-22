using System;
using System.Collections;
using UnityEngine;

namespace Helpers
{
    public abstract class CoroutineBehaviour : MonoBehaviour
    {
        [SerializeField] private float _period = 0.1f;
        
        private Coroutine _updateCoroutine;
        
        public event Action UpdateAction;
        
        protected virtual void OnEnable()
        {
            _updateCoroutine = StartCoroutine(UpdateCoroutine());
        }

        protected virtual void OnDisable()
        {
            if (_updateCoroutine != null)
            {
                StopCoroutine(_updateCoroutine);
                _updateCoroutine = null;
            }
        }
        
        private IEnumerator UpdateCoroutine()
        {
            WaitForSeconds wait = new WaitForSeconds(_period);
        
            while (enabled)
            {
                UpdateAction?.Invoke();
                
                yield return wait;
            }
        }
    }
}