using System;
using InviromentSpace;
using UnityEngine;

namespace UISystem
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private float _levelTimer = 5;

        private static int _wave = 0;
        private float _timer = 0;
        static bool loaded;
        private float _tempLevelTimer;
        
        public delegate void LevelComplete(int wave);
        public static event LevelComplete OnLevelComplete;

        private void OnEnable()
        {
            DestroyByContact.OnKill += OnIsDead;
        }

        void Awake() 
        {
            _tempLevelTimer = _levelTimer;
            
            if (!loaded)
            {
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
            loaded = true;
        }
    
        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _levelTimer)
            {
                _timer = 0;
                _levelTimer++;
                _wave++;
                OnLevelComplete?.Invoke(_wave);
            }
            
            Debug.Log(_levelTimer);
            Debug.Log(_tempLevelTimer);
        }

        private void OnIsDead()
        {
            _levelTimer = _tempLevelTimer;
            _wave = 0;
            _timer = 0;
        }

        private void OnDisable()
        {
            DestroyByContact.OnKill -= OnIsDead;
        }
    }
}