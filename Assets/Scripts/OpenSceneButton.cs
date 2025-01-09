using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OpenSceneButton : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        SceneManager.LoadScene(_sceneName);
    }
}