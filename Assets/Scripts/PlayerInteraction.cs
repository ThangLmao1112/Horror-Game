using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Raycast Settings")]
    public float interactionDistance = 3f;
    public LayerMask interactableLayer;

    [Header("UI")]
    public Text interactionText;

    private Camera playerCamera;
    private CollectibleItem currentItem;
    private DoorController currentDoor;
    void Start()
    {
        playerCamera = Camera.main;

        if (interactionText != null)
        {
            interactionText.text = "";
        }
    }

    void Update()
    {
        CheckForInteractable();

        if (Input.GetKeyDown(KeyCode.E))
        {
            // Nhặt vật phẩm
            if (currentItem != null)
            {
                Debug.Log("🎯 PlayerInteraction: Nhấn E - Đang nhặt vật phẩm: " + currentItem.name); // THÊM DÒNG NÀY
                currentItem.Collect();
                currentItem = null;
                interactionText.text = "";
            }
            // Mở/đóng cửa
            else if (currentDoor != null)
            {
                Debug.Log("🚪 PlayerInteraction: Mở/đóng cửa: " + currentDoor.name); // THÊM DÒNG NÀY
                currentDoor.ToggleDoor();
            }
            else
            {
                Debug.Log("⚠️ PlayerInteraction: Nhấn E nhưng không có vật phẩm hoặc cửa nào!"); // THÊM DÒNG NÀY
            }
        }
    }


    void CheckForInteractable()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            // Kiểm tra vật phẩm
            CollectibleItem item = hit.collider.GetComponent<CollectibleItem>();
            if (item != null)
            {
                currentItem = item;
                interactionText.text = "[E] Nhặt " + item.itemName;
                return;
            }

            // Kiểm tra cửa
            DoorController door = hit.collider.GetComponent<DoorController>();
            if (door != null)
            {
                currentDoor = door;
                interactionText.text = "[E] " + (door.isOpen ? "Đóng cửa" : "Mở cửa");
                return;
            }
        }

        currentItem = null;
        currentDoor = null;
        interactionText.text = "";
    }
}