using UnityEngine;

namespace Detectors.Overlap
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BoxOverlapDetector : BaseOverlapDetector
    {
        private BoxCollider2D _boxCollider2D;
        
        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }
        
        public override Collider2D Detect()
        {
            if (_boxCollider2D == null)
                return null;
            
            return Physics2D.OverlapBox(_boxCollider2D.transform.position, _boxCollider2D.size, 0, _layer);
        }
    }
}