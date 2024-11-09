using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _minSpawnCount = 5;
    [SerializeField] private int _maxSpawnCount = 10;
    
    private List<Transform> _spawnPoints;

    private void Awake()
    {
        _spawnPoints = new List<Transform>();

        foreach (Transform child in transform)
            _spawnPoints.Add(child);
        
        int spawnPointsCount = _spawnPoints.Count;
        int maxSpawnCount = spawnPointsCount > _maxSpawnCount ? _maxSpawnCount : spawnPointsCount;
        int minSpawnCount = Math.Max(1, _minSpawnCount);
        int spawnCount = Random.Range(minSpawnCount, maxSpawnCount);
        SpawnItems(_spawnPoints.ToList(), spawnCount);
    }
    
    private void SpawnItems(List<Transform> spawnPoints, int coinsCount)
    {
        for (int i = 0; i < coinsCount; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Transform spawnPoint = spawnPoints[randomIndex];
            Instantiate(_prefab, spawnPoint.position, Quaternion.identity);
            spawnPoints.RemoveAt(randomIndex);
        }
    }
}