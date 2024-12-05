using System;
using UnityEngine;

public class PlayerDetectBehaviour : MonoBehaviour
{
    public event Action<Transform> PlayerDetected;
    public event Action PlayerLost;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController player))
            PlayerDetected?.Invoke(player.transform);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController player))
            PlayerLost?.Invoke();
    }
}