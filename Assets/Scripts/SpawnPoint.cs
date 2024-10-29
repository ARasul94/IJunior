using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _target;

    public void SpawnEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);
        enemy.SetTarget(_target);
    }
}