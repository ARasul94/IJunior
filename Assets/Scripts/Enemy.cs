using UnityEngine;

[RequireComponent(typeof(MoveBehaviour), typeof(JumpBehaviour), typeof(SpriteFlipper))]
public class Enemy : MonoBehaviour
{
    private SpriteFlipper _spriteFlipper;
    private MoveBehaviour _moveBehaviour;
    private JumpBehaviour _jumpBehaviour;
    private Transform _target;

    protected void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _jumpBehaviour = GetComponent<JumpBehaviour>();
        _spriteFlipper = GetComponent<SpriteFlipper>();
    }
    
    protected void Update()
    {
        if (_target == null)
            return;
        
        if (_jumpBehaviour.IsGrounded == false)
            return;
        
        var directionToTarget = (_target.position - transform.position).normalized;
        _moveBehaviour.Move(directionToTarget.x);
        _spriteFlipper.SetDirection(directionToTarget.x);
    }
    
    public void SetTarget(Transform target)
    {
        _target = target;
    }
}