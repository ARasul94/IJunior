using UnityEngine;

public class Apple: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            Destroy(gameObject);
        }
    }
}