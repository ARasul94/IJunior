using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(MeshRenderer))]
public class ScrolledBackground : MonoBehaviour
{
    [SerializeField] 
    [Tooltip("Скорость прокрутки текстуры по вертикали")]
    private float _textureScrollSpeedY = 0.1f;
    
    [SerializeField]
    [Tooltip("Скорость прокрутки текстуры по горизонтали")]
    private float _textureScrollSpeedX = 0.5f;

    private Material _backgroundMaterial;

    private void Start()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        _backgroundMaterial = meshRenderer.material;
    }

    private void Update()
    {
        UpdateTextureOffset();
    }

    private void UpdateTextureOffset()
    {
        var scrollOffset = new Vector2(_textureScrollSpeedX, _textureScrollSpeedY) * Time.deltaTime;
        _backgroundMaterial.mainTextureOffset += scrollOffset;
    }
}

