using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton để truy cập từ mọi nơi

    [Header("UI")]
    public Text clueCounterText;

    [Header("Gameplay")]
    public int totalClues = 5; // Tổng số manh mối cần tìm
    private int collectedClues = 0;

    void Awake()
    {
        // Thiết lập Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateUI();
    }

    public void CollectClue()
    {
        collectedClues++;
        UpdateUI();

        // Kiểm tra thắng game
        if (collectedClues >= totalClues)
        {
            WinGame();
        }
    }

    void UpdateUI()
    {
        if (clueCounterText != null)
        {
            clueCounterText.text = "Manh mối: " + collectedClues + "/" + totalClues;
        }
    }

    void WinGame()
    {
        Debug.Log("THẮNG! Đã tìm đủ tất cả manh mối!");
        clueCounterText.text = "HOÀN THÀNH! Bạn đã tìm ra bí mật!";
    }
}