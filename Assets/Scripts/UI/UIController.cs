using InviromentSpace;
using TMPro;
using UnityEngine;

namespace UISystem
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverWindow;
        [SerializeField] private GameObject _winWindow;
        [SerializeField] private TextMeshProUGUI _passedWave;
        private void OnEnable()
        {
            DestroyByContact.OnKill += OnOpenGameOverWindow;
            LevelManager.OnLevelComplete += OnOpenWinWindow;
        }

        private void OnOpenGameOverWindow()
        {
            _gameOverWindow.SetActive(true);
            Time.timeScale = 0;
        }

        private void OnOpenWinWindow(int wave)
        {
            _passedWave.text = $"Passed waves: {wave}";
            _winWindow.SetActive(true);
            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            DestroyByContact.OnKill -= OnOpenGameOverWindow;
            LevelManager.OnLevelComplete -= OnOpenWinWindow;
        }
    }
}