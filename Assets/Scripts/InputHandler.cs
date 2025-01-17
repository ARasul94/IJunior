using Abilities;
using Abilities.Base;
using UnityEngine;
using UnityEngine.Serialization;

public class InputHandler : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";

    [SerializeField] private KeyCode _vampireAbilityKeyCode;
    
    public KeyCode VampireAbilityKeyCode => _vampireAbilityKeyCode;

    public float GetHorizontalInput()
    {
        return Input.GetAxis(Horizontal);
    }

    public bool IsJumpRequired()
    {
        return Input.GetButtonDown(Jump);
    }

    public bool IsAttackRequired()
    {
        return Input.GetMouseButtonDown(0);
    }

    public bool IsVampireAbilityRequired()
    {
        return Input.GetKeyDown(_vampireAbilityKeyCode);
    }
}