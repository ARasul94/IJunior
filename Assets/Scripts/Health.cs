using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    public event Action Die;
    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;
    
    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(float amount)
    {
        _currentHealth += amount;

        _currentHealth = Math.Min(_currentHealth, _maxHealth);
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;

        _currentHealth = Math.Max(_currentHealth, 0);
        
        if (_currentHealth <= 0)
            Die?.Invoke();
    }
}