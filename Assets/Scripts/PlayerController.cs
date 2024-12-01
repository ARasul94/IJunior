using UnityEngine;

[RequireComponent(typeof(MoveBehaviour), typeof(JumpBehaviour), typeof(SpriteFlipper))]
public class PlayerController : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";
    
    private SpriteFlipper _spriteFlipper;
    private MoveBehaviour _moveBehaviour;
    private JumpBehaviour _jumpBehaviour;

    private void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _jumpBehaviour = GetComponent<JumpBehaviour>();
        _spriteFlipper = GetComponent<SpriteFlipper>();
    }

    private void Update()
    {
        float direction = Input.GetAxis(Horizontal);
        _moveBehaviour.Move(direction);
        _spriteFlipper.SetDirection(direction);

        if (Input.GetButtonDown(Jump))
            _jumpBehaviour.Jump();
    }
}