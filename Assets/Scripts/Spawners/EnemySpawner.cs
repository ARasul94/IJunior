using System.Collections;
using UnityEngine;

namespace Spawners
{
    public class EnemySpawner : ObjectPoolSpawner
    {
        [SerializeField] private Transform _spawnArea;
        [SerializeField] private float _spawnTime = .1f;
        
        private void Start()
        {
            StartCoroutine(SpawnCoroutine());
        }
        
        private Vector3 GetSpawnPosition()
        {
            Vector3 position = _spawnArea.position;
            Vector3 scale = _spawnArea.localScale;
            float randomX = Random.Range(position.x - scale.x / 2, position.x + scale.x / 2);
            float randomY = Random.Range(position.y - scale.y / 2, position.y + scale.y / 2);
            return new Vector3(randomX, randomY, position.z);
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