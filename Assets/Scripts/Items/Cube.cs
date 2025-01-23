using System;
using System.Collections;
using Helpers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Items
{
    [RequireComponent(typeof(Renderer))]
    public class Cube : ObjectPoolItem
    {
        [SerializeField] private TimerBehaviour _timer;
        
        private bool _hasCollided = false;
        private Renderer _cubeRenderer;

        private void Awake()
        {
            _cubeRenderer = GetComponent<Renderer>();
        }

        private void OnEnable()
        {
            _timer.OnTimerEnded += BackToPool;
        }

        private void OnDisable()
        {
            _timer.OnTimerEnded -= BackToPool;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_hasCollided)
                return;

            Platform platform = collision.gameObject.GetComponent<Platform>();

            if (platform == null) 
                return;
        
            _hasCollided = true;
            _cubeRenderer.material.color = GetRandomColor();
            _timer.StartTimer();
        }

        private Color GetRandomColor()
        {
            return new Color(Random.value, Random.value, Random.value);
        }

        public override void Release()
        {
            _hasCollided = false;
            _cubeRenderer.material.color = Color.white;
        }
    }
}