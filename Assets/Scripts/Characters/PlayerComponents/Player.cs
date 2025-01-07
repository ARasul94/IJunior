using Behaviours;
using UnityEngine;

namespace Characters.PlayerComponents
{
    public class Player : BaseCharacter
    {
        [SerializeField] private InputHandler _inputHandler;
        [SerializeField] private AttackBehaviour _attackBehaviour;
        
        private float _moveDirection = 0;
        private bool _isJumpRequired;
        private bool _isAttackRequired;

        private void Update()
        {
            _moveDirection = _inputHandler.GetHorizontalInput();
            _isJumpRequired = _inputHandler.IsJumpRequired() || _isJumpRequired;
            if (_inputHandler.IsAttackRequired())
                _attackBehaviour.Attack();
        }

        private void FixedUpdate()
        {
            _mover.Move(_moveDirection);

            if (_isJumpRequired)
            {
                _jumper.MakeJump();
                _isJumpRequired = false;
            }
        }
    }
}