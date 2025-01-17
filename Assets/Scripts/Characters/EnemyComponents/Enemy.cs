using Behaviours;
using Detectors;
using Rotators;
using UnityEngine;

namespace Characters.EnemyComponents
{
    [RequireComponent(typeof(GroundDetector))]
    public class Enemy : BaseCharacter
    {
        [SerializeField] private CharacterDetector _characterDetector;
        [SerializeField] private Patroller _patroller;
        [SerializeField] private RotatorToTargetDirection _rotator;
        
        private GroundDetector _groundDetector;
        private Transform _target;

        protected override void Awake()
        {
            base.Awake();
            _groundDetector = GetComponent<GroundDetector>();

            _characterDetector.CharacterDetected += OnCharacterDetected;
            _characterDetector.CharacterLost += OnCharacterLost;
            _health.Died += Died;
        }

        protected void FixedUpdate()
        {
            if (_target == null)
                return;
        
            if (_groundDetector.IsGrounded == false)
                return;
        
            var directionToTarget = (_target.position - transform.position).normalized;
            _mover.Move(directionToTarget.x);
            _rotator.SetTargetDirection(directionToTarget);
        }

        private void OnDestroy()
        {
            _characterDetector.CharacterDetected -= OnCharacterDetected;
            _characterDetector.CharacterLost -= OnCharacterLost;
            _health.Died -= Died;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void OnCharacterDetected(BaseCharacter character)
        {
            _patroller.enabled = false;
            _target = character.transform;
        }
    
        private void OnCharacterLost(BaseCharacter character)
        {
            _target = null;
            _patroller.enabled = true;
        }

        private void Died()
        {
            Destroy(gameObject);
        }
    }
}