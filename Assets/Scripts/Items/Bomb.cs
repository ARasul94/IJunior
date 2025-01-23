using Helpers;
using UnityEngine;

namespace Items
{
    public class Bomb: ObjectPoolItem
    {
        [SerializeField] private TimerBehaviour _timer;
        [SerializeField] private Exploder _exploder;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _materialPrefab;

        private Material _material;
        
        private void Awake()
        {
            _material = new Material(_materialPrefab);
            _meshRenderer.materials = new[] { _material };
        }

        private void OnEnable()
        {
            _timer.OnTimerEnded += Explode;
            _timer.OnTimerEnded += BackToPool;
            _timer.OnTimeChanged += OnTimeChanged;
            
            _timer.StartTimer();
        }

        private void OnDisable()
        {
            _timer.OnTimerEnded -= Explode;
            _timer.OnTimerEnded -= BackToPool;
            _timer.OnTimeChanged -= OnTimeChanged;
        }

        public override void Release()
        {
            SetOpacity(1f);
        }

        private void OnTimeChanged(float time)
        {
            SetOpacity(time / _timer.Max);
        }

        private void Explode()
        {
            _exploder.Explode();
        }

        private void SetOpacity(float opacity)
        {
            var color = _material.color;
            color.a = opacity;
            _material.color = color;
        }
    }
}