using Behaviours;
using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(Mover), typeof(Jumper), typeof(Health))]
    public class BaseCharacter: MonoBehaviour
    {
        protected Mover _mover;
        protected Jumper _jumper;
        protected Health _health;

        public Health Health => _health;

        protected virtual void Awake()
        {
            _mover = GetComponent<Mover>();
            _jumper = GetComponent<Jumper>();
            _health = GetComponent<Health>();
        }
    }
}