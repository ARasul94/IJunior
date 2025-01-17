using Helpers;
using UnityEngine;

namespace Abilities.Base
{
    public abstract class PeriodicAbility : AbilityBase
    {
        protected virtual void OnEnable()
        {
            ActiveTimer.OnTimeChanged += OnActiveTimeChanged;
            ActiveTimer.OnTimerEnded += CooldownTimer.StartTimer;
        }

        protected virtual void OnDisable()
        {
            ActiveTimer.OnTimeChanged -= OnActiveTimeChanged;
            ActiveTimer.OnTimerEnded -= CooldownTimer.StartTimer;
        }

        public override void Use()
        {
            if (IsAvailable == false)
                return;
            
            ActiveTimer.StartTimer();
        }

        private void OnActiveTimeChanged(float time)
        {
            AbilityAction();
        }
    }
}