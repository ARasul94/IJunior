using UnityEngine;

[RequireComponent(typeof(MoveController), typeof(JumpController), typeof(SpriteFlipController))]
public class Enemy : MonoBehaviour
{
    private SpriteFlipController _spriteFlipController;
    private MoveController _moveController;
    private JumpController _jumpController;
    private Transform _target;

    protected void Awake()
    {
        _moveController = GetComponent<MoveController>();
        _jumpController = GetComponent<JumpController>();
        _spriteFlipController = GetComponent<SpriteFlipController>();
    }
    
    protected void Update()
    {
        if (_target == null)
            return;
        
        if (_jumpController.IsGrounded == false)
            return;
        
        var directionToTarget = (_target.position - transform.position).normalized;
        _moveController.Move(directionToTarget.x);
        _spriteFlipController.SetDirection(directionToTarget.x);
    }
    
    public void SetTarget(Transform target)
    {
        _target = target;
    }
}