using UnityEngine;

namespace Rotators
{
    public class RotatorToMoveDirection : RotatorBase
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        protected override void Rotate()
        {
            if (_rigidbody2D.velocity.x > 0)
                transform.rotation = Quaternion.Euler(0, _rotationRight, 0);
            else if (_rigidbody2D.velocity.x < 0)
                transform.rotation = Quaternion.Euler(0, _rotationLeft, 0);
        }
    }
}