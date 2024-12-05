using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private int _healPower = 20;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            var playerHealth = player.GetComponent<Health>();
            
            if (Mathf.Approximately(playerHealth.CurrentHealth, playerHealth.MaxHealth))
                return;
            
            playerHealth.Heal(_healPower);
            Destroy(gameObject);
        }
    }
}