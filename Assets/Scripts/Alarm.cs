using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _volumeChangeSpeed = .5f;
    
    private int _enemyCounts;
    private Coroutine _adjustVolumeCoroutine;

    private void Start()
    {
        _alarmSound.volume = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        bool isEnemy = other.gameObject.GetComponent<Enemy>()!= null;

        if (isEnemy)
            _enemyCounts++;
        
        LaunchCoroutine();
    }

    private void OnTriggerExit(Collider other)
    {
        bool isEnemy = other.gameObject.GetComponent<Enemy>() != null;
        
        if (isEnemy)
            _enemyCounts--;
        
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
        float targetVolume = _enemyCounts > 0 ? 1f : 0f;
        
        while (Mathf.Approximately(_alarmSound.volume, targetVolume) == false)
        {
            _alarmSound.volume =
                Mathf.MoveTowards(_alarmSound.volume, targetVolume, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }

        _adjustVolumeCoroutine = null;
    }
}