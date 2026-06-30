# Hướng Dẫn Cấu Hình Database Cho Feedback & Download Tracker

Hệ thống **Feedback & Download Tracker** trong game hỗ trợ cả **Firebase Realtime Database** và **Google Sheets (Google Forms)**. Dưới đây là các bước cực kỳ đơn giản để cấu hình:

---

## LỰA CHỌN 1: Cấu hình Firebase Realtime Database (Khuyên dùng - Cực kỳ chuyên nghiệp)
Firebase cho phép lưu trữ dữ liệu dạng JSON thời gian thực miễn phí và hỗ trợ đếm số lượt tải về (Download Tracker) chuẩn nhất.

### Bước 1: Tạo Database trên Firebase Console
1. Truy cập [Firebase Console](https://console.firebase.google.com/) và đăng nhập bằng tài khoản Google.
2. Nhấp vào **Add project** (Thêm dự án), điền tên dự án (ví dụ: `Rambo-Frog-Feedback`) và nhấn **Continue**. Bạn có thể bỏ qua bước kích hoạt Google Analytics để tạo nhanh hơn.
3. Khi dự án được tạo xong, nhấp vào **Build** ở thanh menu bên trái -> chọn **Realtime Database**.
4. Nhấp vào **Create Database** (Tạo cơ sở dữ liệu), chọn khu vực (Region) mặc định và nhấn **Next**.
5. Chọn chế độ **Start in test mode** (Bắt đầu ở chế độ thử nghiệm) để cho phép game của bạn ghi dữ liệu mà không cần đăng nhập -> nhấn **Enable** (Kích hoạt).

### Bước 2: Lấy URL và dán vào Unity
1. Bạn sẽ thấy một URL ở phía trên bảng điều khiển cơ sở dữ liệu có dạng: `https://<ten-du-an>-default-rtdb.firebaseio.com/`
2. Sao chép URL này.
3. Trong Unity, nhấp vào GameObject `FeedbackSystem` (đã gắn script `FeedbackManager`).
4. Tại ô **Database Type**, chọn **FirebaseREST**.
5. Dán URL đã sao chép vào ô **Firebase Url**.

---

## LỰA CHỌN 2: Cấu hình Google Sheets / Google Forms (Dành cho lưu file Excel trực tuyến)
Nếu bạn muốn feedback chảy trực tiếp vào file Excel Google Sheets để tiện nộp bài:

### Bước 1: Tạo Google Form
1. Truy cập [Google Forms](https://docs.google.com/forms/) và tạo một biểu mẫu mới.
2. Thêm 3 câu hỏi dạng Text (Short Answer / Paragraph):
   - Câu hỏi 1: `Player Name`
   - Câu hỏi 2: `Rating`
   - Câu hỏi 3: `Feedback Message`
3. Nhấp vào tab **Responses** (Câu trả lời) -> chọn **Link to Sheets** (Liên kết với Trang tính) để tạo một Google Sheet lưu câu trả lời.

### Bước 2: Lấy URL Submit và Entry ID
1. Nhấp vào nút **Preview** (biểu tượng con mắt) ở góc trên bên phải biểu mẫu.
2. Nhấn F12 (hoặc Chuột phải -> Inspect) để mở DevTools của trình duyệt.
3. Tìm kiếm cụm từ `<form` trong code HTML để lấy URL gửi. Nó sẽ có dạng: `https://docs.google.com/forms/d/e/.../formResponse`. Dán URL này vào ô **Google Form Url** trong Unity.
4. Tìm kiếm các thuộc tính `name="entry.XXXXX"` trong các ô nhập liệu của Form Preview để lấy mã số ID của từng câu hỏi:
   - Thay các mã số này vào các ô tương ứng: **Name Entry Id**, **Rating Entry Id**, **Feedback Entry Id** trong Unity Inspector.

---

## Hướng dẫn gán GameObject trong Unity
1. Mở Scene `MainMenu` trong Unity.
2. Chọn thanh menu phía trên: **GameObject -> Create Empty**. Đổi tên nó thành `FeedbackSystem`.
3. Kéo thả script `FeedbackManager.cs` ở thư mục `Assets/Scripts/` vào GameObject `FeedbackSystem` vừa tạo.
4. Chạy game (Play)! Nút **"Update Log & Feedback"** sẽ tự động hiển thị ở góc dưới bên trái màn hình. Bạn có thể nhấn vào để mở giao diện, xem nhật ký, xem danh mục asset và gửi feedback thử nghiệm.
