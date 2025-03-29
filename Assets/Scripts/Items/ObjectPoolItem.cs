using System;
using UnityEngine;

namespace Items
{
    public abstract class ObjectPoolItem : MonoBehaviour
    {
        public event Action<ObjectPoolItem> OnBackToPool;

        public abstract void Release();

        protected void BackToPool()
        {
            OnBackToPool?.Invoke(this);
        }
    }
}