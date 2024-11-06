using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    private Transform _target;
    
    protected void Update()
    {
        if (_target == null)
            return;
        
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
    
    public void SetTarget(Transform target)
    {
        _target = target;
    }
}