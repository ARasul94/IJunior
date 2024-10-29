using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private float _spawnInterval = 2f;
    
    private void Start()
    {
        StartCoroutine(SpawnEnemiesCoroutine());
    }
    
    private IEnumerator SpawnEnemiesCoroutine()
    {
        while (true)
        {
            var spawnPointIndex = Random.Range(0, _spawnPoints.Count);
            var randomSpawnPoint = _spawnPoints[spawnPointIndex];
            randomSpawnPoint.SpawnEnemy();
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}