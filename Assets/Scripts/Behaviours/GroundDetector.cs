using System;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    public class GroundDetector: CoroutineBehaviour
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _groundCheckDistance = 0.1f;
        [SerializeField] private LayerMask _groundLayer;
        
        private bool _isGrounded;
        
        public bool IsGrounded => _isGrounded;

        protected override void OnEnable()
        {
            UpdateAction += UpdateGroundedStatus;
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            UpdateAction -= UpdateGroundedStatus;
            base.OnDisable();
        }

        private void UpdateGroundedStatus()
        {
            RaycastHit2D hit = Physics2D.Raycast(_groundCheck.position, Vector2.down, _groundCheckDistance, _groundLayer);
            _isGrounded = hit.collider != null;
        }
    }
}