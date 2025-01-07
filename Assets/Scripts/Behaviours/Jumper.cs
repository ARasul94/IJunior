using System.Collections;
using UnityEngine;

namespace Behaviours
{
    [RequireComponent(typeof(Rigidbody2D), typeof(GroundDetector))]
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 10f;
        
        private Rigidbody2D _rigidbody2D;
        private GroundDetector _groundDetector;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _groundDetector = GetComponent<GroundDetector>();
        }

        public void MakeJump()
        {
            if (_groundDetector.IsGrounded)
                _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}