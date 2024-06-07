using AsteroidSpace;
using UnityEngine;

namespace UISystem
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverWindow;
        private void OnEnable()
        {
            AsteroidCollider.OnKill += OnOpenGameOverWindow;
        }

        private void OnOpenGameOverWindow()
        {
            _gameOverWindow.SetActive(true);
            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            AsteroidCollider.OnKill -= OnOpenGameOverWindow;
        }
    }
}