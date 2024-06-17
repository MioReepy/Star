using UnityEngine;
using UnityEngine.SceneManagement;

namespace UISystem
{
    public class LevelCompleteWindow : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1f;
                gameObject.SetActive(false);
            }
        }
    }
}