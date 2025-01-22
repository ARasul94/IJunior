using System;
using System.Collections.Generic;
using Abilities.Base;
using Characters;
using Detectors;
using Extensions;
using UnityEngine;

namespace Abilities
{
    public class VampireAbility : PeriodicAbility
    {
        [SerializeField] private CharacterDetector _enemyDetector;
        [SerializeField] private BaseCharacter _player;
        [SerializeField] private float _damagePerUse = 5;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private List<BaseCharacter> _targets = new List<BaseCharacter>();
        
        protected override void OnEnable()
        {
            base.OnEnable();

            ActiveTimer.OnTimerStated += OnAbilityActivated;
            ActiveTimer.OnTimerEnded += OnAbilityDeactivated;
            _enemyDetector.CharacterDetected += OnCharacterDetected;
            _enemyDetector.CharacterLost += OnCharacterLost;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            
            ActiveTimer.OnTimerStated -= OnAbilityActivated;
            ActiveTimer.OnTimerEnded -= OnAbilityDeactivated;
            _enemyDetector.CharacterDetected -= OnCharacterDetected;
            _enemyDetector.CharacterLost -= OnCharacterLost;
        }

        protected override void AbilityAction()
        {
            BaseCharacter nearestTarget = null;
            float nearestDistance = Mathf.Infinity;
            
            foreach (BaseCharacter target in _targets)
            {
                if (target.Health.IsAlive == false)
                    continue;

                float distance = _player.transform.position.SqrDistance(target.transform.position);
                
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestTarget = target;
                }
            }
            
            if (nearestTarget == null)
                return;
            
            float damage = Mathf.Min(_damagePerUse, nearestTarget.Health.Current);
            nearestTarget.Health.TakeDamage(damage);
            _player.Health.TakeHeal(damage);
        }

        private void OnAbilityActivated()
        {
            _spriteRenderer.enabled = true;
        }

        private void OnAbilityDeactivated()
        {
            _spriteRenderer.enabled = false;
        }

        private void OnCharacterDetected(BaseCharacter detectedCharacter)
        {
            if (_targets.Contains(detectedCharacter) == false)
                _targets.Add(detectedCharacter);
        }

        private void OnCharacterLost(BaseCharacter lostCharacter)
        {
            if (_targets.Contains(lostCharacter))
                _targets.Remove(lostCharacter);
        }
    }
}