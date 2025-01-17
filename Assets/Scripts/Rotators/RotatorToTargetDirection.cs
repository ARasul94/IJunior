using UnityEngine;

namespace Rotators
{
    public class RotatorToTargetDirection : RotatorBase
    {
        private Vector3 _targetDirection;
        
        public void SetTargetDirection(Vector3 targetDirection)
        {
            _targetDirection = targetDirection;
        }
        
        protected override void Rotate()
        {
            if (_targetDirection.x > 0)
                transform.rotation = Quaternion.Euler(0, _rotationRight, 0);
            else if (_targetDirection.x < 0)
                transform.rotation = Quaternion.Euler(0, _rotationLeft, 0);
        }
    }
}