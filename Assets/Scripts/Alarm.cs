using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _volumeChangeSpeed = .5f;
    
    private int _enemyCounts;

    private void Start()
    {
        _alarmSound.volume = 0f;
    }

    private void Update()
    {
        float targetVolume = _enemyCounts > 0 ? 1f : 0f;

        _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, targetVolume, _volumeChangeSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        bool isEnemy = other.gameObject.GetComponent<Enemy>()!= null;

        if (isEnemy)
            _enemyCounts++;
    }

    private void OnTriggerExit(Collider other)
    {
        bool isEnemy = other.gameObject.GetComponent<Enemy>() != null;
        
        if (isEnemy)
            _enemyCounts--;
    }
}