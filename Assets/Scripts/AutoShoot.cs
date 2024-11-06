using System.Collections;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _timeWaitShooting;
    
    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds waiter = new WaitForSeconds(_timeWaitShooting);

        while (enabled)
        {
            Vector3 vector3direction = (_target.position - transform.position).normalized;
            Rigidbody newBullet = Instantiate(_bulletPrefab, transform.position + vector3direction, Quaternion.identity);

            newBullet.transform.forward = vector3direction;
            newBullet.velocity = vector3direction * _speed;

            yield return waiter;
        }
    }
}