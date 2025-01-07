using System;
using Characters.PlayerComponents;
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
            OnCoinCountChanged();
        }

        private void OnEnable()
        {
            _inventory.CoinCountChanged += OnCoinCountChanged;
        }

        private void OnDisable()
        {
            _inventory.CoinCountChanged -= OnCoinCountChanged;
        }

        private void OnCoinCountChanged()
        {
            _countField.text = _inventory.CoinsCount.ToString();
        }
    }
}