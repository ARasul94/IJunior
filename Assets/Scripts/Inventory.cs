using System;
using Items;
using UnityEngine;

public class Inventory: MonoBehaviour
{
    private int _coinsCount;

    public int CoinsCount => _coinsCount;
    
    public event Action CoinCountChanged;

    private void Awake()
    {
        _coinsCount = 0;
    }

    public void AddItem(Item item)
    {
        if (item is Coin)
        {
            _coinsCount++;
            CoinCountChanged?.Invoke();
        }
    }
}