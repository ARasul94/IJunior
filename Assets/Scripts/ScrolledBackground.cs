using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class ScrolledBackground : MonoBehaviour
{
    [SerializeField] private float _scrollYSpeed = 0.1f;
    [SerializeField] private float _scrollXSpeed = 0.5f;

    private MeshRenderer _meshRenderer;
    private Material _material;
    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _material = _meshRenderer.material;
    }

    private void Update()
    {
        var xOffset = Input.GetAxis("Horizontal") * _scrollXSpeed;
        var verticalInput = Input.GetAxis("Vertical");
        var yOffset = _scrollYSpeed + (verticalInput > 0 ? verticalInput : 0) * _scrollYSpeed;
        var offset = new Vector2(xOffset, yOffset);
        _material.mainTextureOffset += offset * Time.deltaTime;
    }
}
