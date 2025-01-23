using Spawners;
using TMPro;
using UnityEngine;

public class SpawnInfoDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _spawnField;
    [SerializeField] private TextMeshProUGUI _activeField;
    [SerializeField] private TextMeshProUGUI _createdField;
    [SerializeField] private ObjectPoolSpawner _spawner;

    private void Update()
    {
        _spawnField.text = _spawner.SpawnCount.ToString();
        _activeField.text = _spawner.ActiveCount.ToString();
        _createdField.text = _spawner.CreatedCount.ToString();
    }
}