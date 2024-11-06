using System.Collections.Generic;
using UnityEngine;

public class MoveByWaypoints : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _waypointsHolder;
    
    private List<Transform> _waypoints;
    private int _waypointIndex;
    private float _minimalDistanceToWaypoint = 0.1f;

    private void Start()
    {
        _waypoints = new List<Transform>();

        foreach (Transform waypoint in _waypointsHolder)
            _waypoints.Add(waypoint);
    }

    private void Update()
    {
        var targetPoint = _waypoints[_waypointIndex];
        transform.position =
            Vector3.MoveTowards(transform.position, targetPoint.position, _speed * Time.deltaTime);

        if (transform.position.IsEnoughClose(targetPoint.position, _minimalDistanceToWaypoint))
            SelectNextPoint();
    }

    private void SelectNextPoint()
    {
        _waypointIndex++;

        if (_waypointIndex >= _waypoints.Count)
            _waypointIndex = 0;

        var thisPointVector = _waypoints[_waypointIndex].transform.position;
        transform.forward = thisPointVector - transform.position;
    }
}