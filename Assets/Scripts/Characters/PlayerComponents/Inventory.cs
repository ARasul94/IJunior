using System;
using Items;
using UnityEngine;

namespace Characters.PlayerComponents
{
    public class Inventory: MonoBehaviour
    {
        private int _coinsCount;

        public int CoinsCount => _coinsCount;
    
        public event Action CoinCountChanged;

        private void Awake()
        {
            _coinsCount = 0;
        }

        public void AddCoin(Coin coin)
        {
            _coinsCount++;
            CoinCountChanged?.Invoke();
        }
    }
}