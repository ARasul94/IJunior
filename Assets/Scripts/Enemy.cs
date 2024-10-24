using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _destoyDelay = 5f;
    [SerializeField] private float _speed = 5f;
    
    private Vector3 _movementDirection;

    private void Awake()
    {
        Destroy(gameObject, _destoyDelay);
    }

    public void SetMovementDirection(Vector3 direction)
    {
        _movementDirection = direction.normalized;
    }

    private void Update()
    {
        transform.position += _movementDirection * _speed * Time.deltaTime;
    }
}