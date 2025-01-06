using UnityEngine;

namespace Behaviours
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _power;
    
        private float _cooldown;
        private Health _target;

        private void Awake()
        {
            _cooldown = 0;
        }

        private void Update()
        {
            if (_cooldown > 0)
            {
                _cooldown -= Time.deltaTime;
                return;
            }

            if (_target == null)
                return;
        
            _target.TakeDamage(_power);
            _cooldown = _speed;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Health target))
                _target = target;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (_target == null)
                return;

            if (other.gameObject.TryGetComponent(out Health target) && _target == target)
                _target = null;
        }
    }
}