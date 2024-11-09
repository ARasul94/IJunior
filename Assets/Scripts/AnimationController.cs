using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private JumpController _jumpController;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;

    private int _isGroundedHash;
    private int _speedYHash;
    private int _speedXHash;
    
    private void Awake()
    {
        _isGroundedHash = Animator.StringToHash("IsGrounded");
        _speedYHash = Animator.StringToHash("SpeedY");
        _speedXHash = Animator.StringToHash("SpeedX");
    }

    private void Update()
    {
        _animator.SetBool(_isGroundedHash, _jumpController.IsGrounded);
        _animator.SetFloat(_speedYHash, _rigidbody.velocity.y);
        _animator.SetFloat(_speedXHash, Mathf.Abs(_rigidbody.velocity.x));
    }
}