using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private int _rotationRight;
    [SerializeField] private int _rotationLeft;
    

    private void Update()
    {
        if (_rigidbody2D.velocity.x > 0)
            transform.rotation = Quaternion.Euler(0, _rotationRight, 0);
        else if (_rigidbody2D.velocity.x < 0)
            transform.rotation = Quaternion.Euler(0, _rotationLeft, 0);
    }
}