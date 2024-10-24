using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _spawnInterval = 2f;

    private readonly float _randomRange = 1f;

    private void Start()
    {
        StartCoroutine(SpawnEnemiesCoroutine());
    }
    
    private IEnumerator SpawnEnemiesCoroutine()
    {
        while (true)
        {
            SpawnEnemyAtRandomPoint();
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void SpawnEnemyAtRandomPoint()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Count);
        Transform spawnPoint = _spawnPoints[randomIndex];
        
        Enemy enemy = Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        
        Vector3 moveDirection = new Vector3(
            Random.Range(-_randomRange, _randomRange), 
            0f, 
            Random.Range(-_randomRange, _randomRange));
        enemy.SetMovementDirection(moveDirection);
    }
}