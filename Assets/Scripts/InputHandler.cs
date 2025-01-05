using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";

    public float GetHorizontalInput()
    {
        return Input.GetAxis(Horizontal);
    }

    public bool IsJumpRequired()
    {
        return Input.GetButtonDown(Jump);
    }
}