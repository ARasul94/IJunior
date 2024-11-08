using System;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public int EnemyCounts => _enemyCounts;
    public event Action EnemyEntered;
    public event Action EnemyExited;
    
    private int _enemyCounts;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy _))
        {
            _enemyCounts++;
            EnemyEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Enemy _))
        {
            _enemyCounts--;
            EnemyExited?.Invoke();
        }
    }
}