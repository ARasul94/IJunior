using UnityEngine;

[RequireComponent(typeof(MoveController), typeof(JumpController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    private MoveController _moveController;
    private JumpController _jumpController;

    private void Awake()
    {
        _moveController = GetComponent<MoveController>();
        _jumpController = GetComponent<JumpController>();
    }

    private void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        _moveController.Move(direction);
        _spriteRenderer.flipX = direction < 0;

        if (Input.GetButtonDown("Jump"))
            _jumpController.Jump();
    }
}