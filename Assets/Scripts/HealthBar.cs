using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthField;
    [SerializeField] private Health _health;

    private void Update()
    {
        _healthField.text = $"{_health.CurrentHealth:N0}/{_health.MaxHealth:N0}";
    }
}