using System;
using Helpers;
using UnityEngine;

namespace Abilities.Base
{
    public abstract class AbilityBase : MonoBehaviour
    {
        [SerializeField] private TimerBehaviour _coolDownTimer;
        [SerializeField] private TimerBehaviour _activeTimer;
        
        public TimerBehaviour CooldownTimer => _coolDownTimer;
        public TimerBehaviour ActiveTimer => _activeTimer;
        public bool IsActive => ActiveTimer != null && ActiveTimer.Finished == false;
        public bool IsAvailable => _coolDownTimer.Finished && IsActive == false;

        public virtual void Use()
        {
            if (IsAvailable == false)
                return;
            
            AbilityAction();
            CooldownTimer.StartTimer();
        }

        protected abstract void AbilityAction();
    }
}