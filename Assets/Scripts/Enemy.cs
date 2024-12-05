using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(MoveBehaviour), typeof(JumpBehaviour))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerDetectBehaviour _playerDetectBehaviour;
    [SerializeField] private PatrolBehaviour _patrolBehaviour;
    
    private MoveBehaviour _moveBehaviour;
    private JumpBehaviour _jumpBehaviour;
    private Transform _target;

    protected void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _jumpBehaviour = GetComponent<JumpBehaviour>();

        _playerDetectBehaviour.PlayerDetected += OnPlayerDetected;
        _playerDetectBehaviour.PlayerLost += OnPlayerLost;
    }
    
    protected void Update()
    {
        if (_target == null)
            return;
        
        if (_jumpBehaviour.IsGrounded == false)
            return;
        
        var directionToTarget = (_target.position - transform.position).normalized;
        _moveBehaviour.Move(directionToTarget.x);
    }
    
    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void OnPlayerDetected(Transform player)
    {
        _patrolBehaviour.enabled = false;
        _target = player;
    }
    
    private void OnPlayerLost()
    {
        _target = null;
        _patrolBehaviour.enabled = true;
    }
}