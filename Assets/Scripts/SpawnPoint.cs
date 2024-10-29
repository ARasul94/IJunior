using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    
    private readonly float _randomInterval = 1f;

    public void SpawnEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);
        
        Vector3 moveDirection = new Vector3(
            Random.Range(-_randomInterval, _randomInterval), 
            0f, 
            Random.Range(-_randomInterval, _randomInterval));
        enemy.SetMovementDirection(moveDirection);
    }
}