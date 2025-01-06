using UnityEngine;

namespace Behaviours
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
    
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Move(float direction)
        {
            Vector2 velocity = _rigidbody2D.velocity;
            velocity.x = direction * _moveSpeed;
            _rigidbody2D.velocity = velocity;
        }
    }
}