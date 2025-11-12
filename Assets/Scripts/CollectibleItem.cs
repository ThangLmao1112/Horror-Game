using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [Header("Thu thập vật phẩm")]
    public string itemName = "Manh mối bí ẩn";
    public AudioClip collectSound; // Âm thanh khi thu thập (tùy chọn)

    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra xem có phải người chơi chạm vào không
        if (other.CompareTag("Player"))
        {
            CollectItem();
        }
    }

    void CollectItem()
    {
        // Thông báo cho GameManager
        if (GameManager.Instance != null)
        {
            GameManager.Instance.CollectClue();
        }

        // Phát âm thanh (nếu có)
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }

        // Xóa vật phẩm khỏi game
        Destroy(gameObject);
    }
}