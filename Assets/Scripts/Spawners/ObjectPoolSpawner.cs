using System.Collections;
using Items;
using UnityEngine;
using UnityEngine.Pool;

namespace Spawners
{
    public abstract class ObjectPoolSpawner : MonoBehaviour
    {
        [SerializeField] private ObjectPoolItem _prefab;
        [SerializeField] private Transform _holder;
        
        public int SpawnCount { get; private set; }
        public int CreatedCount => _pool.CountAll;
        public int ActiveCount => _pool.CountActive;

        private ObjectPool<ObjectPoolItem> _pool;

        protected virtual void Awake()
        {
            _pool = new ObjectPool<ObjectPoolItem>(
                OnCreate,
                OnGet,
                OnRelease,
                OnDestroyObject
            );

            SpawnCount = 0;
        }

        public void Spawn(Vector3 spawnPosition)
        {
            ObjectPoolItem poolItem = _pool.Get();
            poolItem.transform.position = spawnPosition;
            SpawnCount++;
        }
        
        protected virtual void OnBackToPool(ObjectPoolItem expiredObject)
        {
            _pool.Release(expiredObject);
        }

        private ObjectPoolItem OnCreate()
        {
            var createdObject = Instantiate(_prefab, _holder);
            createdObject.onBackToPool += OnBackToPool;
            return createdObject;
        }

        private void OnGet(ObjectPoolItem poolItem)
        {
            poolItem.gameObject.SetActive(true);
        }
    
        private void OnRelease(ObjectPoolItem poolItem)
        {
            poolItem.gameObject.SetActive(false);
            poolItem.Release();
        }

        private void OnDestroyObject(ObjectPoolItem poolItem)
        {
            poolItem.onBackToPool -= OnBackToPool;
            Destroy(poolItem.gameObject);
        }
    }
}