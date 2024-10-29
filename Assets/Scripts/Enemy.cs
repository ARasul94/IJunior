using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _destroyDelay = 5f;
    [SerializeField] private float _speed = 5f;
    
    private Vector3 _movementDirection;

    private void Awake()
    {
        Destroy(gameObject, _destroyDelay);
    }
    
    private void Update()
    {
        transform.position += _movementDirection * _speed * Time.deltaTime;
    }

    public void SetMovementDirection(Vector3 direction)
    {
        _movementDirection = direction.normalized;
    }
}