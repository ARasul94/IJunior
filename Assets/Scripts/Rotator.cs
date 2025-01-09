using System;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private Vector3 _rotateAxis = Vector3.up;
    
    
    private void Update()
    {
        transform.Rotate(_rotateAxis, _speed * Time.deltaTime, Space.Self);
    }
}