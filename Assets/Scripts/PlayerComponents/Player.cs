using System;
using Behaviours;
using Items;
using UnityEngine;

namespace PlayerComponents
{
    [RequireComponent(typeof(Mover), typeof(Jumper))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputHandler _inputHandler;
    
        private Mover _mover;
        private Jumper _jumper;
        private float _moveDirection = 0;
        private bool _isJumpRequired;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
            _jumper = GetComponent<Jumper>();
        }

        private void Update()
        {
            _moveDirection = _inputHandler.GetHorizontalInput();
            _isJumpRequired = _inputHandler.IsJumpRequired() || _isJumpRequired;
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