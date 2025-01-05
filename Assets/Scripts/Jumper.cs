using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckDistance = 0.1f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckPeriod = 0.1f;
    
    public bool IsGrounded => _isGrounded;
    
    private bool _isGrounded;
    private Rigidbody2D _rigidbody2D;
    private Coroutine _updateCoroutine;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _updateCoroutine = StartCoroutine(UpdateGroundedCoroutine());
    }

    private void OnDisable()
    {
        if (_updateCoroutine != null)
        {
            StopCoroutine(_updateCoroutine);
            _updateCoroutine = null;
        }
    }

    public void MakeJump()
    {
        UpdateGroundedStatus();
        
        if (_isGrounded)
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private IEnumerator UpdateGroundedCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_groundCheckPeriod);
        
        while (true)
        {
            UpdateGroundedStatus();
            yield return wait;
        }
    }

    private void UpdateGroundedStatus()
    {
        RaycastHit2D hit = Physics2D.Raycast(_groundCheck.position, Vector2.down, _groundCheckDistance, _groundLayer);
        _isGrounded = hit.collider != null;
    }
}