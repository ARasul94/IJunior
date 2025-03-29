using System;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Transform _trackedObject;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        var position = transform.position;
        position.x = _trackedObject.position.x + _xOffset;

        transform.position = position;
    }
}