using System;
using UnityEngine;

namespace Items
{
    public abstract class ObjectPoolItem : MonoBehaviour
    {
        public event Action<ObjectPoolItem> onBackToPool;

        public abstract void Release();

        protected void BackToPool()
        {
            onBackToPool?.Invoke(this);
        }
    }
}