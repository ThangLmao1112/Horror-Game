using UnityEngine;
using UnityEngine.UI;

public class ClueStory : MonoBehaviour
{
    [Header("UI References")]
    public GameObject cluePanel;
    public Text clueContent;

    [Header("Story Content")]
    private string[] clueStories = new string[5];

    private bool isReadingClue = false;

    // Hàm public để các script khác kiểm tra trạng thái
    public bool IsReadingClue()
    {
        return isReadingClue;
    }

    void Start()
    {
        // Ẩn panel khi bắt đầu
        if (cluePanel != null)
        {
            cluePanel.SetActive(false);
        }

        // Định nghĩa 5 câu chuyện
        clueStories[0] = @"<b>NHẬT KÝ CỦA DÂN LÀNG (1887)</b>

        'Ngày 15 tháng 10 năm 1887

        Linh mục Ezekiel đã thay đổi. Ông ta không còn 
        cầu nguyện cho Chúa nữa. Mỗi đêm, từ nhà thờ 
        cũ trong rừng vọng ra những tiếng rên rỉ kỳ lạ.

        Người dân làng bắt đầu biến mất. Trước hết là 
        cậu bé Thomas, rồi cụ già Margaret... 

        Ai đó phải ngăn ông ta lại... trước khi quá muộn.'

        - Mary Johnson";

                clueStories[1] = @"<b>BẢN CÁO TRẠNG (1888)</b>

        'HỒ SƠ ĐIỀU TRA - MẬT

        Ngày 3 tháng 3 năm 1888

        Sau 7 vụ mất tích, chúng tôi đột kích nhà thờ 
        cũ. Những gì tìm thấy... không thể tin được.

        Xương người xếp thành hình ngũ giác. Sách cấm 
        viết bằng máu. Và tượng của một vị thần xa lạ 
        không thuộc về thế giới này.

        Father Ezekiel đã chết trong nghi lễ triệu hồi. 
        Nhưng thi thể ông ta... đã biến mất vào đêm đó.

        Dân làng nói: ""Ông ta vẫn còn ở đây. Ông ta sẽ 
        mãi mãi ở đây.""'

        - Thám tử William Reed";

                clueStories[2] = @"<b>THƯ CỦA LINH MỤC EZEKIEL</b>

        'Thượng đế đã bỏ rơi tôi.

        Tôi cầu nguyện cho con gái tôi Emily khi nàng 
        đau ốm. Tôi van xin. Tôi khóc lóc. Nhưng Ngài 
        im lặng. Và Emily đã chết trong vòng tay tôi.

        Nếu Thượng đế không cứu con tôi, tôi sẽ tìm 
        đến kẻ khác. Tôi đã tìm thấy cuốn sách cổ trong 
        tầng hầm nhà thờ. Nó nói về sức mạnh vượt qua 
        cái chết.

        Ngày mai, tôi sẽ thực hiện nghi lễ. Tôi sẽ đưa 
        Emily trở lại. Dù phải đánh đổi linh hồn mình.

        Dù phải đánh đổi cả thế giới này.'

        - Father Ezekiel, 1887";

                clueStories[3] = @"<b>BÁO CŨ (1952)</b>

        'TIN TỨC ĐỊA PHƯƠNG - BÁO BLACKWOOD

        THÊM 3 DU KHÁCH MẤT TÍCH TẠI RỪNG CẤM

        Tuần này, 3 sinh viên từ thành phố đã mất tích 
        khi cắm trại gần nhà thờ cũ. Cảnh sát tìm thấy 
        lều trại bị phá hủy, nhưng không có dấu vết của 
        họ.

        Đây là vụ mất tích thứ 47 kể từ năm 1888.

        Thị trưởng Johnson cảnh báo: ""Hãy tránh xa khu 
        rừng đó. Có thứ gì đó ở đó... và nó không chết 
        được.""'

        - Báo Blackwood, 15/6/1952";

                clueStories[4] = @"<b>LỜI NGUYỀN</b>

        'BẠN ĐÃ TÌM THẤY SỰ THẬT

        Father Ezekiel đã thất bại. Nghi lễ không hồi 
        sinh Emily... mà biến ông ta thành quái vật.

        Ông ta bất tử. Ông ta giận dữ. Và ông ta săn 
        lùng bất kỳ ai dám xâm phạm khu rừng này.

        Linh hồn ông ta bị trói buộc với mảnh đất này 
        mãi mãi. Trừ phi...

        [Phần còn lại của giấy bị xé nát bởi móng vuốt]

        CHẠY ĐI. CHẠY ĐI NGAY BÂY GIỜ.
        CHẠY ĐI TRƯỚC KHI ÔNG TA TÌM THẤY BẠN!'

        - Ẩn danh";
            }

    void Update()
    {
        if (isReadingClue && Input.GetKeyDown(KeyCode.Q))
        {
            CloseClue();
        }
    }

    public void ShowClue(int clueIndex)
    {
        if (clueIndex < 0 || clueIndex >= clueStories.Length) return;

        // Hiện panel
        if (cluePanel != null)
        {
            cluePanel.SetActive(true);
        }

        // Hiện nội dung
        if (clueContent != null)
        {
            clueContent.text = clueStories[clueIndex];
        }

        // Dừng game và hiện chuột
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isReadingClue = true;

        Debug.Log("Đang đọc manh mối số: " + (clueIndex + 1));
    }

    public void CloseClue()
    {
        // Ẩn panel
        if (cluePanel != null)
        {
            cluePanel.SetActive(false);
        }

        // Tiếp tục game
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isReadingClue = false;
    }
}