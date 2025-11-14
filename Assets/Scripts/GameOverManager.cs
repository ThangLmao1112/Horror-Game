using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    void Start()
    {
        // Ẩn panel khi bắt đầu
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Đảm bảo game chạy bình thường
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0; // Dừng game
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        Debug.Log("GAME OVER!");
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Chạy lại game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}