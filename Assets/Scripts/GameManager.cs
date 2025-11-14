using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton để truy cập từ mọi nơi

    public Text warningText;

    [Header("Enemy System")]
    public EnemyAI enemy; // Kéo CursedPriest vào đây
    public int cluesBeforeEnemySpawn = 2; // Số manh mối để spawn sát nhân
    private bool enemySpawned = false;

    [Header("UI")]
    public Text clueCounterText;

    [Header("Gameplay")]
    public int totalClues = 5; // Tổng số manh mối cần tìm
    private int collectedClues = 0;

    public int GetCollectedClues()
    {
        return collectedClues;
    }
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

        // Ẩn warning text ban đầu
        if (warningText != null)
        {
            warningText.text = "";
        }
    }

    public void CollectClue()
    {
        collectedClues++;
        UpdateUI();

        // Spawn sát nhân khi đủ 2 manh mối
        if (!enemySpawned && collectedClues >= cluesBeforeEnemySpawn)
        {
            SpawnEnemy();
        }

        // Kiểm tra thắng game
        if (collectedClues >= totalClues)
        {
            WinGame();
        }
    }
    void SpawnEnemy()
    {
        enemySpawned = true;

        if (enemy != null)
        {
            enemy.ActivateEnemy();
            Debug.Log("⚠️ SÁT NHÂN ĐÃ XUẤT HIỆN! HÃY CHẠY TRỐN!");

            // Hiển thị cảnh báo
            if (warningText != null)
            {
                StartCoroutine(ShowWarning());
            }
        }
    }

    System.Collections.IEnumerator ShowWarning()
    {
        warningText.text = "⚠️ SÁT NHÂN ĐÃ XUẤT HIỆN! ⚠️";
        yield return new WaitForSeconds(5f); // Hiện 5 giây
        warningText.text = "";
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