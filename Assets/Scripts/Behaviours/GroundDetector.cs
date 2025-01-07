using System.Collections;
using UnityEngine;

namespace Behaviours
{
    public class GroundDetector: MonoBehaviour
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _groundCheckDistance = 0.1f;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundCheckPeriod = 0.1f;
        
        private bool _isGrounded;
        private Coroutine _updateCoroutine;
        
        public bool IsGrounded => _isGrounded;
        
        private void OnEnable()
        {
            _updateCoroutine = StartCoroutine(UpdateGroundedCoroutine());
        }

        private void OnDisable()
        {
            if (_updateCoroutine != null)
            {
                StopCoroutine(_updateCoroutine);
                _updateCoroutine = null;
            }
        }
        
        private IEnumerator UpdateGroundedCoroutine()
        {
            WaitForSeconds wait = new WaitForSeconds(_groundCheckPeriod);
        
            while (true)
            {
                UpdateGroundedStatus();
                yield return wait;
            }
        }

        private void UpdateGroundedStatus()
        {
            RaycastHit2D hit = Physics2D.Raycast(_groundCheck.position, Vector2.down, _groundCheckDistance, _groundLayer);
            _isGrounded = hit.collider != null;
        }
    }
}