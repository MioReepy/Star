using AsteroidSpace;
using UnityEngine;

namespace UISystem
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverWindow;
        private void OnEnable()
        {
            DestroyByContact.OnKill += OnOpenGameOverWindow;
        }

        private void OnOpenGameOverWindow()
        {
            _gameOverWindow.SetActive(true);
            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            DestroyByContact.OnKill -= OnOpenGameOverWindow;
        }
    }
}