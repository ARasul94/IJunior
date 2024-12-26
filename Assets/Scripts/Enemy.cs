using UnityEngine;

[RequireComponent(typeof(MoveBehaviour), typeof(JumpBehaviour))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerDetectBehaviour _playerDetectBehaviour;
    [SerializeField] private PatrolBehaviour _patrolBehaviour;
    [SerializeField] private Health _health;
    
    private MoveBehaviour _moveBehaviour;
    private JumpBehaviour _jumpBehaviour;
    private Transform _target;

    protected void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _jumpBehaviour = GetComponent<JumpBehaviour>();

        _playerDetectBehaviour.PlayerDetected += OnPlayerDetected;
        _playerDetectBehaviour.PlayerLost += OnPlayerLost;
        _health.Died += Died;
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

    private void OnDestroy()
    {
        _playerDetectBehaviour.PlayerDetected -= OnPlayerDetected;
        _playerDetectBehaviour.PlayerLost -= OnPlayerLost;
        _health.Died -= Died;
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

    private void Died()
    {
        Destroy(gameObject);
    }
}