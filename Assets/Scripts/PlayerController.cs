using UnityEngine;

[RequireComponent(typeof(MoveController), typeof(JumpController), typeof(SpriteFlipController))]
public class PlayerController : MonoBehaviour
{
    private SpriteFlipController _spriteFlipController;
    private MoveController _moveController;
    private JumpController _jumpController;

    private void Awake()
    {
        _moveController = GetComponent<MoveController>();
        _jumpController = GetComponent<JumpController>();
        _spriteFlipController = GetComponent<SpriteFlipController>();
    }

    private void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        _moveController.Move(direction);
        _spriteFlipController.SetDirection(direction);

        if (Input.GetButtonDown("Jump"))
            _jumpController.Jump();
    }
}