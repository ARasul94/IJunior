using Items;
using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Jumper), typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private InputHandler _inputHandler;
    
    private Mover _mover;
    private Jumper _jumper;
    private Health _health;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _jumper = GetComponent<Jumper>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        float direction = _inputHandler.GetHorizontalInput();
        _mover.Move(direction);

        if (_inputHandler.IsJumpRequired())
            _jumper.MakeJump();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Item item))
        {
            if (item is HealthPack healthPack)
            {
                if (_health.IsNeedHeal())
                {
                    _health.TakeHeal(healthPack.HealPower);
                    Destroy(healthPack.gameObject);
                }
            }
            else if (item is Coin coin)
            {
                _inventory.AddCoin(coin);
                Destroy(coin.gameObject);
            }
        }
    }
}