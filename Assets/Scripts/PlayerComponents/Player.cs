using System;
using UnityEngine;

namespace PlayerComponents
{
    [RequireComponent(typeof(CollisionHandler))]
    public class Player : MonoBehaviour
    {
        private CollisionHandler _collisionHandler;
        
        private void Awake()
        {
            _collisionHandler = GetComponent<CollisionHandler>();
        }

        private void ProcessCollision(IInteractable interactable)
        {
            
        }
    }
}