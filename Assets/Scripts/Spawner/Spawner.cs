using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawner
{
    public abstract class Spawner<T> : MonoBehaviour where T: MonoBehaviour
    {
        [SerializeField] private T _prefab;
        [SerializeField][Min(0)] private int _minSpawnCount = 5;
        [SerializeField][Min(1)] private int _maxSpawnCount = 10;
    
        private List<Transform> _spawnPoints;

        private void Awake()
        {
            _spawnPoints = new List<Transform>();

            foreach (Transform child in transform)
                _spawnPoints.Add(child);
        
            int spawnPointsCount = _spawnPoints.Count;
            int maxSpawnCount = spawnPointsCount > _maxSpawnCount ? _maxSpawnCount : spawnPointsCount;
            int spawnCount = Random.Range(_minSpawnCount, maxSpawnCount);
            SpawnItems(_spawnPoints.ToList(), spawnCount);
        }
    
        private void SpawnItems(List<Transform> spawnPoints, int needSpawnCount)
        {
            for (int i = 0; i < needSpawnCount; i++)
            {
                int randomIndex = Random.Range(0, spawnPoints.Count);
                Transform spawnPoint = spawnPoints[randomIndex];
                Instantiate(_prefab, spawnPoint.position, Quaternion.identity);
                spawnPoints.RemoveAt(randomIndex);
            }
        }

        private void OnValidate()
        {
            if (_minSpawnCount >= _maxSpawnCount)
                _maxSpawnCount = _minSpawnCount + 1;
        }
    }
}