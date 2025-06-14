using System;
using PoolItems;
using UnityEngine;
using UnityEngine.Pool;

namespace Spawners
{
    public abstract class ObjectPoolSpawner<T> : MonoBehaviour where T : ObjectPoolItem
    {
        [SerializeField] private T _prefab;
        [SerializeField] private Transform _holder;

        private ObjectPool<T> _pool;

        protected virtual void Awake()
        {
            _pool = new ObjectPool<T>(
                OnCreate,
                OnGet,
                OnRelease,
                OnDestroyObject
            );
        }

        private void OnDestroy()
        {
            _pool.Dispose();
        }

        public void Spawn(Vector3 spawnPosition)
        {
            T poolItem = _pool.Get();
            poolItem.transform.position = spawnPosition;
        }

        public void Release(T poolItem)
        {
            _pool.Release(poolItem);
        }

        private T OnCreate()
        {
            var createdObject = Instantiate(_prefab, _holder);
            return createdObject;
        }

        private void OnGet(T poolItem)
        {
            poolItem.gameObject.SetActive(true);
        }
    
        private void OnRelease(T poolItem)
        {
            poolItem.gameObject.SetActive(false);
            poolItem.Release();
        }

        private void OnDestroyObject(T poolItem)
        {
            Destroy(poolItem.gameObject);
        }
    }
}