using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _max = 100;

    public event Action Died;
    public event Action Changed;
    public float Current => _current;
    public float Max => _max;
    
    private float _current;

    private void Awake()
    {
        _current = _max;
    }

    public bool IsNeedHeal()
    {
        if (Mathf.Approximately(_current, _max))
            return false;

        return true;
    }

    public void TakeHeal(float amount)
    {
        _current += amount;
        _current = Math.Min(_current, _max);
        Changed?.Invoke();
    }

    public void TakeDamage(float amount)
    {
        _current -= amount;

        _current = Math.Max(_current, 0);
        Changed?.Invoke();
        
        if (_current <= 0)
            Died?.Invoke();
    }
}