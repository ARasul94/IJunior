using Characters;
using Detectors;
using HealthPackage.Scripts.Behaviours;
using UnityEngine;

namespace Behaviours
{
    public class AttackBehaviour: MonoBehaviour
    {
        [SerializeField] private CharacterDetector _characterDetector;
        [SerializeField] private Attack _attack;
        [SerializeField] private bool _autoAttack;

        private Health _health;

        private void Update()
        {
            if (_attack.IsAvailable == false)
                return;

            if (_autoAttack)
                Attack();
        }

        private void OnEnable()
        {
            _characterDetector.CharacterDetected += OnCharacterDetected;
            _characterDetector.CharacterLost += OnCharacterLost;
        }

        private void OnDisable()
        {
            _characterDetector.CharacterDetected -= OnCharacterDetected;
            _characterDetector.CharacterLost -= OnCharacterLost;
        }

        public void Attack()
        {
            if (_health == null)
                return;
            
            _attack.MakeAttack(_health);
        }

        private void OnCharacterDetected(BaseCharacter character)
        {
            _health = character.Health;
        }

        private void OnCharacterLost(BaseCharacter character)
        {
            _health = null;
        }
    }
}