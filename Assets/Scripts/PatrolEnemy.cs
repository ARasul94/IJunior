using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : Enemy
{
    [SerializeField] private List<Transform> _waypoints;
    
    private float _minimalDistanceToWaypoint = 0.1f;
    private int _currentWaypointIndex;
    
    private new void Awake()
    {
        base.Awake();
        
        SetTarget(_waypoints[_currentWaypointIndex]);
    }

    private new void Update()
    {
        base.Update();
        
        if (transform.position.IsEnoughClose(_waypoints[_currentWaypointIndex].position, _minimalDistanceToWaypoint))
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Count;
            SetTarget(_waypoints[_currentWaypointIndex]);
        }
    }
}