using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    
    public void Initialize(Vector3 direction)
    {
        transform.forward = direction;
        _rigidbody.velocity = direction * _speed;
    }
}