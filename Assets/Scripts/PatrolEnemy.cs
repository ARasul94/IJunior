using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : Enemy
{
    [SerializeField] private List<Transform> _waypoints;
    
    private Transform _currentWaypoint;
    
    private void Awake()
    {
        _currentWaypoint = _waypoints[0];
        SetTarget(_currentWaypoint);
    }

    private new void Update()
    {
        base.Update();
        
        if (_distance < 0.1f)
        {
            var currentIndex = _waypoints.IndexOf(_currentWaypoint);
            var nextIndex = (currentIndex + 1) % _waypoints.Count;
            _currentWaypoint = _waypoints[nextIndex];
            SetTarget(_currentWaypoint);
        }
    }
}