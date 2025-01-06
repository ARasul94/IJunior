using System.Collections.Generic;
using Helpers;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Enemy))]
    public class Patroller : MonoBehaviour
    {
        [SerializeField] private List<Transform> _waypoints;
 
        private Enemy _enemy;
        private float _minimalDistanceToWaypoint = 0.1f;
        private int _currentWaypointIndex;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
        }

        private void OnEnable()
        {
            _enemy.SetTarget(_waypoints[_currentWaypointIndex]);
        }

        private void Update()
        {
            if (transform.position.IsEnoughClose(_waypoints[_currentWaypointIndex].position, _minimalDistanceToWaypoint))
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Count;
                _enemy.SetTarget(_waypoints[_currentWaypointIndex]);
            }
        }
    }
}