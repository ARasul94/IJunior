using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : Enemy
{
    [SerializeField] private List<Transform> _waypoints;
    
    private int _currentWaypointIndex;
    
    private void Awake()
    {
        SetTarget(_waypoints[_currentWaypointIndex]);
    }

    private new void Update()
    {
        base.Update();
        
        if (_distance < 0.1f)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Count;
            SetTarget(_waypoints[_currentWaypointIndex]);
        }
    }
}