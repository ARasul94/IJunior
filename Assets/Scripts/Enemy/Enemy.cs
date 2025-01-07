using System;
using Behaviours;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Mover), typeof(GroundDetector))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private PlayerDetector _playerDetector;
        [SerializeField] private Patroller _patroller;
        [SerializeField] private Health _health;
    
        private Mover _mover;
        private GroundDetector _groundDetector;
        private Transform _target;

        protected void Awake()
        {
            _mover = GetComponent<Mover>();
            _groundDetector = GetComponent<GroundDetector>();

            _playerDetector.PlayerDetected += OnPlayerDetected;
            _playerDetector.PlayerLost += OnPlayerLost;
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
        }

        private void OnDestroy()
        {
            _playerDetector.PlayerDetected -= OnPlayerDetected;
            _playerDetector.PlayerLost -= OnPlayerLost;
            _health.Died -= Died;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void OnPlayerDetected(Transform player)
        {
            _patroller.enabled = false;
            _target = player;
        }
    
        private void OnPlayerLost()
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