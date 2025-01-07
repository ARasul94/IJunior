using System;
using Helpers;
using PlayerComponents;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerDetector : CoroutineBehaviour
    {
        [SerializeField] private LayerMask _layer;

        private BoxCollider2D _boxCollider2D;
        private Player _player;
        
        public event Action<Transform> PlayerDetected;
        public event Action PlayerLost;

        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        protected override void OnEnable()
        {
            UpdateAction += Detect;
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            UpdateAction -= Detect;
            base.OnDisable();
        }

        private void Detect()
        {
            Collider2D overlapedCollider = Physics2D.OverlapBox(_boxCollider2D.transform.position, _boxCollider2D.size, 0, _layer);

            if (_player == null)
            {
                if (overlapedCollider == null)
                    return;

                if (overlapedCollider.TryGetComponent(out _player))
                    PlayerDetected?.Invoke(_player.transform);
            }
            else
            {
                if (overlapedCollider != null)
                    return;

                _player = null;
                PlayerLost?.Invoke();
            }
        }
    }
}