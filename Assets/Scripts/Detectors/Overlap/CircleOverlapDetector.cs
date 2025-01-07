using UnityEngine;

namespace Detectors.Overlap
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class CircleOverlapDetector: BaseOverlapDetector
    {
        private CircleCollider2D _circleCollider2D;

        private void Awake()
        {
            _circleCollider2D = GetComponent<CircleCollider2D>();
        }
        
        public override Collider2D Detect()
        {
            if (_circleCollider2D == null)
                return null;
            
            return Physics2D.OverlapCircle(_circleCollider2D.transform.position, _circleCollider2D.radius, _layer);
        }
    }
}