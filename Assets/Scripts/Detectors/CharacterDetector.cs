using System;
using Characters;
using Detectors.Overlap;
using Helpers;
using UnityEngine;

namespace Detectors
{
    public abstract class CharacterDetector : CoroutineBehaviour
    {
        [SerializeField] private BaseOverlapDetector _overlapDetector;
        
        private BaseCharacter _character;
        
        public event Action<BaseCharacter> CharacterDetected;
        public event Action CharacterLost;

        protected override void OnEnable()
        {
            UpdateAction += Detect;
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            UpdateAction -= Detect;
            base.OnDisable();
        }

        private void Detect()
        {
            Collider2D overlapedCollider = _overlapDetector.Detect();

            if (_character == null)
            {
                if (overlapedCollider == null)
                    return;

                if (overlapedCollider.TryGetComponent(out _character))
                    CharacterDetected?.Invoke(_character);
            }
            else
            {
                if (overlapedCollider != null)
                    return;

                _character = null;
                CharacterLost?.Invoke();
            }
        }
    }
}