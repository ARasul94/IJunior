using System;
using PoolItems;
using UnityEngine;

namespace EnemyComponents
{
    public class Enemy: ObjectPoolItem, IInteractable
    {
        [SerializeField] private float _speed = 5f;

        private void Update()
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }

        public override void Release()
        {
        }
    }
}