using UnityEngine;

[RequireComponent(typeof(MoveBehaviour), typeof(JumpBehaviour))]
public class PlayerController : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";
    
    private MoveBehaviour _moveBehaviour;
    private JumpBehaviour _jumpBehaviour;

    private void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _jumpBehaviour = GetComponent<JumpBehaviour>();
    }

    private void Update()
    {
        float direction = Input.GetAxis(Horizontal);
        _moveBehaviour.Move(direction);

        if (Input.GetButtonDown(Jump))
            _jumpBehaviour.Jump();
    }
}