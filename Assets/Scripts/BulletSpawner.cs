using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _timeWaitShooting;
    
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds waiter = new WaitForSeconds(_timeWaitShooting);

        while (enabled)
        {
            Vector3 vector3direction = (_target.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_bulletPrefab, transform.position + vector3direction, Quaternion.identity);
            newBullet.Initialize(vector3direction);

            yield return waiter;
        }
    }
}