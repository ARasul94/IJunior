using Behaviours;
using UnityEngine;

namespace Animations
{
    public class AnimationSwitcher : MonoBehaviour
    {
        private const string IsGrounded = nameof(IsGrounded);
        private const string SpeedX = nameof(SpeedX);
        private const string SpeedY = nameof(SpeedY);
        
        [SerializeField] private Jumper _jumper;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Animator _animator;

        private int _isGroundedHash;
        private int _speedYHash;
        private int _speedXHash;
    
        private void Awake()
        {
            _isGroundedHash = Animator.StringToHash(IsGrounded);
            _speedYHash = Animator.StringToHash(SpeedY);
            _speedXHash = Animator.StringToHash(SpeedX);
        }

        private void Update()
        {
            _animator.SetBool(_isGroundedHash, _jumper.IsGrounded);
            _animator.SetFloat(_speedYHash, _rigidbody.velocity.y);
            _animator.SetFloat(_speedXHash, Mathf.Abs(_rigidbody.velocity.x));
        }
    }
}