using System;
using Abilities;
using Abilities.Base;
using Helpers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SkillDisplayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _buttonField;
        [SerializeField] private Image _coolDownImage;
        [SerializeField] private Image _activeImage;
        [SerializeField] private AbilityBase _ability;
        [SerializeField] private InputHandler _inputHandler;

        private void Awake()
        {
            _buttonField.text = _inputHandler.VampireAbilityKeyCode.ToString();
        }

        private void OnEnable()
        {
            _ability.CooldownTimer.OnTimeChanged += OnCoolDownTimeChanged;
            _ability.ActiveTimer.OnTimeChanged += OnActiveTimeChanged;
        }

        private void OnDisable()
        {
            _ability.CooldownTimer.OnTimeChanged -= OnCoolDownTimeChanged;
            _ability.ActiveTimer.OnTimeChanged -= OnActiveTimeChanged;
        }

        private void OnCoolDownTimeChanged(float time)
        {
            UpdateState(_ability.CooldownTimer, _coolDownImage, time);
        }
        
        private void OnActiveTimeChanged(float time)
        {
            UpdateState(_ability.ActiveTimer, _activeImage, time);
        }

        private void UpdateState(TimerBehaviour timer, Image image, float currentTime)
        {
            image.gameObject.SetActive(timer.Finished == false);
            image.fillAmount = currentTime / timer.Max;
        }
    }
}