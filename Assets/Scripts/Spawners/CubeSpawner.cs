using System.Collections;
using Items;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawners
{
    public class CubeSpawner : ObjectPoolSpawner
    {
        [SerializeField] private Transform _spawnArea;
        [SerializeField] private float _spawnTime = .1f;
        [SerializeField] private BombSpawner _bombSpawner;

        private void Start()
        {
            StartCoroutine(SpawnCoroutine());
        }

        protected override void OnBackToPool(ObjectPoolItem expiredObject)
        {
            _bombSpawner.Spawn(expiredObject.transform.position);
            base.OnBackToPool(expiredObject);
        }

        private Vector3 GetSpawnPosition()
        {
            float randomX = Random.Range(_spawnArea.position.x - _spawnArea.localScale.x / 2,
                _spawnArea.position.x + _spawnArea.localScale.x / 2);
            float randomZ = Random.Range(_spawnArea.position.z - _spawnArea.localScale.z / 2,
                _spawnArea.position.z + _spawnArea.localScale.z / 2);
            return new Vector3(randomX, _spawnArea.position.y, randomZ);
        }
        
        private IEnumerator SpawnCoroutine()
        {
            WaitForSeconds waiter = new WaitForSeconds(_spawnTime);
        
            while (enabled)
            {
                Spawn(GetSpawnPosition());
                yield return waiter;
            }
        }
    }
}