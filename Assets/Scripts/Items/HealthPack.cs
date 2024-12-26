using UnityEngine;

namespace Items
{
    public class HealthPack : Item
    {
        [SerializeField] private int _healPower = 20;

        public int HealPower => _healPower;
    }
}