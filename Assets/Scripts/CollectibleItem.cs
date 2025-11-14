using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [Header("Thông tin vật phẩm")]
    public string itemName = "Manh mối bí ẩn";
    public AudioClip collectSound;

    public void Collect()
    {
        Debug.Log("Nhặt vật phẩm: " + itemName);

        // Tìm GameManager
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            // LẤY INDEX HIỆN TẠI TRƯỚC KHI TĂNG
            int currentClueIndex = gameManager.GetCollectedClues();

            // TĂNG SỐ MANH MỐI
            gameManager.CollectClue();

            // HIỂN THỊ CÂU CHUYỆN
            ClueStory clueStory = FindObjectOfType<ClueStory>();
            if (clueStory != null)
            {
                clueStory.ShowClue(currentClueIndex);
                
            }
        }

        // Phát âm thanh
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }

        // Xóa vật phẩm
        Destroy(gameObject);
    }
}