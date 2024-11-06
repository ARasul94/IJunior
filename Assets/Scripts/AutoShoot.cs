using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AutoShoot : MonoBehaviour
{
    [SerializeField] private float _number;
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private Transform _objectToShoot;
    [SerializeField] private float _timeWaitShooting;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds waiter = new WaitForSeconds(_timeWaitShooting);
        bool isWork = enabled;

        while (isWork)
        {
            var vector3direction = (_objectToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_bulletPrefab, transform.position + vector3direction, Quaternion.identity);

            newBullet.transform.up = vector3direction;
            newBullet.velocity = vector3direction * _number;

            yield return waiter;
        }
    }
}