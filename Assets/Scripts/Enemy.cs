using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Jump))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerDetectBehaviour _playerDetectBehaviour;
    [SerializeField] private Patroller _patroller;
    [SerializeField] private Health _health;
    
    private Mover _mover;
    private Jump _jump;
    private Transform _target;

    protected void Awake()
    {
        _mover = GetComponent<Mover>();
        _jump = GetComponent<Jump>();

        _playerDetectBehaviour.PlayerDetected += OnPlayerDetected;
        _playerDetectBehaviour.PlayerLost += OnPlayerLost;
        _health.Died += Died;
    }
    
    protected void Update()
    {
        if (_target == null)
            return;
        
        if (_jump.IsGrounded == false)
            return;
        
        var directionToTarget = (_target.position - transform.position).normalized;
        _mover.Move(directionToTarget.x);
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