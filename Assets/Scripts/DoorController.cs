using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Cài đặt cửa")]
    public float openAngle = 90f;
    public float openSpeed = 2f;
    public bool isOpen = false;

    [Header("Điểm xoay (Pivot Offset)")]
    public Vector3 pivotOffset = new Vector3(-0.5f, 0, 0); // Điều chỉnh để đặt pivot ở cạnh cửa

    private Vector3 originalPosition;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    private Vector3 pivotPoint;

    void Start()
    {
        originalPosition = transform.position;
        closedRotation = transform.rotation;
        openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0);

        // Tính điểm xoay (bản lề) dựa trên offset
        pivotPoint = transform.position + transform.TransformDirection(pivotOffset);
    }

    void Update()
    {
        Quaternion targetRotation = isOpen ? openRotation : closedRotation;

        // Xoay quanh pivot point
        transform.RotateAround(pivotPoint, Vector3.up,
            Quaternion.Angle(transform.rotation, targetRotation) * openSpeed * Time.deltaTime *
            (isOpen ? 1f : -1f));

        // Giới hạn góc xoay
        if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
        {
            transform.rotation = targetRotation;
        }
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        Debug.Log("Cửa " + (isOpen ? "mở" : "đóng"));
    }
}