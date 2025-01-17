using UnityEngine;

namespace Rotators
{
    public abstract class RotatorBase : MonoBehaviour
    {
        [SerializeField] protected int _rotationRight;
        [SerializeField] protected int _rotationLeft;

        protected void Update()
        {
            Rotate();
        }

        protected abstract void Rotate();
    }
}