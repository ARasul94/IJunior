using Detectors;
using UnityEngine;

namespace Behaviours
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _power;
    
        private float _cooldown;

        public bool IsAvailable => _cooldown <= 0;

        private void Awake()
        {
            _cooldown = 0;
        }

        private void Update()
        {
            if (_cooldown > 0)
                _cooldown -= Time.deltaTime;
        }

        public void MakeAttack(Health target)
        {
            if (IsAvailable)
            {
                target.TakeDamage(_power);
                _cooldown = _speed;
            }
        }
    }
}