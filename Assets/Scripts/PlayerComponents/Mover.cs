using UnityEngine;

namespace PlayerComponents
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _tapForce;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _minRotationZ;
        [SerializeField] private float _maxRotationZ;

        private Rigidbody2D _rigidbody2D;
        private Vector3 _startPosition;
        private Quaternion _minRotation;
        private Quaternion _maxRotation;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _startPosition = transform.position;

            _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
            _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody2D.velocity = new Vector2(_speed, _tapForce);
                transform.rotation = _maxRotation;
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}