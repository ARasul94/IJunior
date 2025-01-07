using Behaviours;
using Items;
using UnityEngine;

namespace PlayerComponents
{
    [RequireComponent(typeof(Health), typeof(Inventory))]
    public class Collector: MonoBehaviour
    {
        private Inventory _inventory;
        private Health _health;
        
        private void Awake()
        {
            _health = GetComponent<Health>();
            _inventory = GetComponent<Inventory>();
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
}