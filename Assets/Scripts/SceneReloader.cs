using Characters.PlayerComponents;
using HealthPackage.Scripts.Behaviours;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class SceneReloader : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;

    private void Awake()
    {
        _playerHealth.Died += ReloadScene;
    }

    private void OnDestroy()
    {
        _playerHealth.Died -= ReloadScene;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player _))
            ReloadScene();
    }

    private void ReloadScene()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.buildIndex);
    }
}