using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button),typeof(AudioSource))]
public class SoundButton : MonoBehaviour
{
    private Button _button;
    private AudioSource _audioSource;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _audioSource = GetComponent<AudioSource>();
        
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        _audioSource.Play();
    }
}