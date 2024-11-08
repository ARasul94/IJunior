using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private EnemyDetector _enemyDetector;
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _volumeChangeSpeed = .5f;
    
    private Coroutine _adjustVolumeCoroutine;

    private void Start()
    {
        _alarmSound.volume = 0f;
    }

    private void OnEnable()
    {
        _enemyDetector.EnemyEntered += OnEnemyEntered;
        _enemyDetector.EnemyExited += OnEnemyExited;
    }

    private void OnDisable()
    {
        _enemyDetector.EnemyEntered -= OnEnemyEntered;
        _enemyDetector.EnemyExited -= OnEnemyExited;
    }
    
    private void OnEnemyEntered()
    {
        LaunchCoroutine();
    }
    
    private void OnEnemyExited()
    {
        LaunchCoroutine();
    }
    
    private void LaunchCoroutine()
    {
        if (_adjustVolumeCoroutine != null)
            StopCoroutine(_adjustVolumeCoroutine);

        _adjustVolumeCoroutine = StartCoroutine(AdjustVolume());
    }

    private IEnumerator AdjustVolume()
    {
        float targetVolume = _enemyDetector.EnemyCounts > 0 ? 1f : 0f;
        
        while (Mathf.Approximately(_alarmSound.volume, targetVolume) == false)
        {
            _alarmSound.volume =
                Mathf.MoveTowards(_alarmSound.volume, targetVolume, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }

        _adjustVolumeCoroutine = null;
    }
}