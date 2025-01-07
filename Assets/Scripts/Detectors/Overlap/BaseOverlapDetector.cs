using UnityEngine;

namespace Detectors.Overlap
{
    public abstract class BaseOverlapDetector : MonoBehaviour
    {
        [SerializeField] protected LayerMask _layer;
        
        public abstract Collider2D Detect();
    }
}