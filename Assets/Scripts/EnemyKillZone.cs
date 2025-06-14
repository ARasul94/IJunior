using EnemyComponents;
using UnityEngine;
using PoolItems;
using Spawners;

[RequireComponent(typeof(CollisionHandler))]
public class EnemyKillZone : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    
    private CollisionHandler _collisionHandler;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _collisionHandler.CollisionDetected += OnCollisionDetected;
    }

    private void OnCollisionDetected(IInteractable interactable)
    {
        if (interactable is Enemy enemy)
            _enemySpawner.Release(enemy);
    }

    private void OnDestroy()
    {
        if (_collisionHandler != null)
            _collisionHandler.CollisionDetected -= OnCollisionDetected;
    }
}