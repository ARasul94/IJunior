using System;
using PlayerComponents;
using UnityEngine;

namespace Enemy
{
    public class PlayerDetector : MonoBehaviour
    {
        public event Action<Transform> PlayerDetected;
        public event Action PlayerLost;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log($"detected {other.gameObject.name} by {gameObject.name}");
            if (other.TryGetComponent(out Player player))
                PlayerDetected?.Invoke(player.transform);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player player))
                PlayerLost?.Invoke();
        }
    }
}