using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private const string MusicVolume = "MusicVolume";
    private const string SoundVolume = "SoundVolume";
    private const string MasterVolume = "MasterVolume";
    private const int AudioLevelMultiplayer = 20;
    private const float AudioMinLevel = 0.0001f;
    
    [SerializeField] private Toggle _audioToggler;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    private bool _isAudioOn = true;

    private void Awake()
    {
        _soundSlider.minValue = AudioMinLevel;
        _musicSlider.minValue = AudioMinLevel;
        _masterSlider.minValue = AudioMinLevel;
        
        _audioToggler.onValueChanged.AddListener(OnAudioStateChanged);
        _soundSlider.onValueChanged.AddListener(OnSoundVolumeChanged);
        _musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        _masterSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
    }

    private void OnAudioStateChanged(bool isOn)
    {
        _isAudioOn = isOn;
        OnMusicVolumeChanged(_musicSlider.value);
        OnSoundVolumeChanged(_soundSlider.value);
        OnMasterVolumeChanged(_masterSlider.value);
    }

    private void OnMusicVolumeChanged(float volume)
    {
        SetVolume(MusicVolume, volume);
    }
    
    private void OnSoundVolumeChanged(float volume)
    {
        SetVolume(SoundVolume, volume);
    }
    
    private void OnMasterVolumeChanged(float volume)
    {
        SetVolume(MasterVolume, volume);
    }

    private void SetVolume(string mixerName, float volume)
    {
        _audioMixerGroup.audioMixer.SetFloat(mixerName, GetAdjustedVolume(volume));
    }

    private float GetAdjustedVolume(float volume)
    {
        return Mathf.Log10(_isAudioOn ? volume : AudioMinLevel) * AudioLevelMultiplayer;
    }
}