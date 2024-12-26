using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CoinDisplayer: MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private TextMeshProUGUI _countField;

        private void Awake()
        {
            _inventory.CoinCountChanged += OnCoinCountChanged;
            
            OnCoinCountChanged();
        }

        private void OnDestroy()
        {
            _inventory.CoinCountChanged -= OnCoinCountChanged;
        }

        private void OnCoinCountChanged()
        {
            _countField.text = _inventory.CoinsCount.ToString();
        }
    }
}