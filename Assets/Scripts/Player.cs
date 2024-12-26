using System;
using Items;
using UnityEngine;

[RequireComponent(typeof(MoveBehaviour), typeof(JumpBehaviour), typeof(Health))]
public class Player : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";

    [SerializeField] private Inventory _inventory;
    
    private MoveBehaviour _moveBehaviour;
    private JumpBehaviour _jumpBehaviour;
    private Health _health;

    private void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _jumpBehaviour = GetComponent<JumpBehaviour>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        float direction = Input.GetAxis(Horizontal);
        _moveBehaviour.Move(direction);

        if (Input.GetButtonDown(Jump))
            _jumpBehaviour.Jump();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Item item))
        {
            if (item is HealthPack)
            {
                if (Mathf.Approximately(_health.Current, _health.Max))
                    return;
                
                _health.TakeHeal((item as HealthPack).HealPower);
                Destroy(item.gameObject);
            }
            else if (item is Coin)
            {
                _inventory.AddItem(item);
                Destroy(item.gameObject);
            }
        }
    }
}