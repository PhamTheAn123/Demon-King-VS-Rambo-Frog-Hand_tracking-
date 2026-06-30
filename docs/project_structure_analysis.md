# Phân Tích Cấu Trúc Dự Án (Harvested via CodeGraph)

Dự án game **Demon King vs Rambo Frog** (kết hợp Hand Tracking) được xây dựng trên nền tảng Unity 2D. Dưới đây là cấu trúc chi tiết của các lớp nhân vật, hệ thống nhận diện cử chỉ, kẻ địch, Boss và môi trường được thu thập thông qua công cụ CodeGraph.

---

## 1. Hệ Thống Điều Khiển & Nhận Diện Cử Chỉ (Hand Tracking & Input)

### Lớp [HandInputProvider](file:///e:/game/UnityProjects/UnityChess3DPvPOnline/Demon-King-VS-Rambo-Frog-Hand_tracking-/Assets/Scripts/HandTracking/HandInputProvider.cs)
Chịu trách nhiệm giao tiếp với hệ thống Mediapipe để đọc kết quả Landmark bàn tay, tính toán số ngón tay xòe và chuyển thành các tín hiệu điều khiển game.

*   **Trạng thái đầu ra (Properties):**
    *   `MoveX` (float): Hướng di chuyển ngang (-1 đến 1).
    *   `JumpDown` / `JumpHeld` / `JumpUp` (bool): Trạng thái nhảy.
    *   `ShootDown` / `ShootHeld` (bool): Trạng thái bắn súng.
    *   `AimScreenPos` (Vector2): Vị trí ngắm bắn trên màn hình (đầu ngón tay trỏ).
    *   `HasHand` (bool): Có bàn tay trong khung hình camera hay không.
*   **Các phương thức cốt lõi:**
    *   `Update()`: Vòng lặp cập nhật mỗi frame. Reset input và đọc dữ liệu từ `HandLandmarkerRunner`.
    *   `ProcessSingleHand()`: Xử lý cử chỉ nếu chỉ dùng 1 tay (gộp di chuyển, nhảy, bắn, ngắm).
    *   `UpdateMovementFromHand()`: Đếm ngón tay xòe (1 ngón $\rightarrow$ sang trái; 2+ ngón $\rightarrow$ sang phải).
    *   `UpdateLeftHandGestures()`: Kiểm tra cử chỉ nhảy (>= 4 ngón xòe $\rightarrow$ nhảy).
    *   `UpdateRightHandAim()`: Lấy tọa độ landmark ngón trỏ (landmark số 8) và tính khoảng cách ngón cái (landmark số 4) tới khớp ngón trỏ (landmark số 5) để quyết định bắn (`ShootHeld` khi khoảng cách < 0.06f).

---

## 2. Lớp Điều Khiển Nhân Vật & Vũ Khí (Player & Gun)

### Lớp [PlayerController](file:///e:/game/UnityProjects/UnityChess3DPvPOnline/Demon-King-VS-Rambo-Frog-Hand_tracking-/Assets/Scripts/Player/PlayerController.cs)
Quản lý trạng thái vật lý của người chơi (di chuyển mượt, nhảy, nhảy kép), chuyển đổi giữa Hand Tracking và Bàn phím/Chuột truyền thống.

*   **Các thành phần chính:**
    *   `handInput`: Giao tiếp với `HandInputProvider`.
    *   `gunController`: Giao tiếp với súng của nhân vật.
    *   `smokeFX`: Hiệu ứng hạt khói khi chạy/nhảy kép.
*   **Các phương thức cốt lõi:**
    *   `UpdateInputs()`: Đọc dữ liệu điều khiển. Nếu `useHandTracking` và `handInput.HasHand` bằng `true` thì nhận dữ liệu từ camera và chuyển đổi Aim từ tọa độ màn hình sang tọa độ thế giới (`ScreenToWorldPoint`). Ngược lại, chuyển về đọc bàn phím (`Horizontal`, `Space`) và chuột.
    *   `HandleMovementInput()` & `ApplyMovement()`: Tăng tốc/giảm tốc mượt mà dựa trên `MoveX` và áp dụng vào Rigidbody2D.
    *   `HandleJumpInput()`: Nhảy thường nếu đang đứng trên mặt đất (`isGrounded`), hoặc nhảy kép (`Double Jump`) nếu đang trên không và còn lượt (`canDoubleJump = true`).

### Lớp [GunController](file:///e:/game/UnityProjects/UnityChess3DPvPOnline/Demon-King-VS-Rambo-Frog-Hand_tracking-/Assets/Scripts/Player/GunController.cs)
Quản lý đạn dược, bắn đạn, và tự động nạp đạn (Reload).

*   **Trạng thái đạn:** `currentClip` (đạn trong băng - tối đa 7), `currentAmmo` (đạn dự trữ - tối đa 30).
*   **Các phương thức cốt lõi:**
    *   `Shoot()`: Nếu còn đạn trong băng (`currentClip > 0`), khởi tạo một Bullet Prefab tại họng súng, truyền lực bay vật lý, phát âm thanh bắn, trừ đạn và chạy Animation bắn. Nếu bắn hết đạn băng và còn đạn dự trữ, kích hoạt Coroutine nạp đạn tự động.
    *   `ReloadCoroutine()`: Trạng thái chờ nạp đạn (1.5 giây), cập nhật số lượng đạn từ dự trữ vào băng.

---

## 3. Hệ Thống Boss (Demon King)

### Lớp [BossController](file:///e:/game/UnityProjects/UnityChess3DPvPOnline/Demon-King-VS-Rambo-Frog-Hand_tracking-/Assets/Scripts/Boss/BossController.cs)
Là Máy trạng thái điều khiển hành vi của Boss "Demon King".

*   **Các trạng thái tấn công:**
    *   `ChaseAttack` (Tấn công đuổi theo).
    *   `DashAttack` (Tấn công lướt nhanh).
    *   `ShootFireballsAttack` (Bắn cầu lửa).
*   **Các phương thức cốt lõi:**
    *   `Update()`: Cập nhật timer trạng thái, hướng về phía người chơi, và chọn đòn tấn công phù hợp dựa trên khoảng cách (`ChooseAttackByDistance`) hoặc chọn ngẫu nhiên (`ChooseRandomAttack`).
    *   `MoveAndJumpToPlatform()`: Giúp Boss di chuyển và nhảy qua lại giữa 2 điểm tiêu chuẩn (`targetA` và `targetB`).

---

## 4. Hệ Thống Kẻ Địch (Enemies)

### Lớp [GroundEnemy](file:///e:/game/UnityProjects/UnityChess3DPvPOnline/Demon-King-VS-Rambo-Frog-Hand_tracking-/Assets/Scripts/Enemy/GroundEnemy/GroundEnemy.cs)
Kẻ địch đi bộ tuần tra trên mặt đất giữa hai giới hạn trái/phải (`leftLimit` và `rightLimit`).

*   **Hành vi:**
    *   Tự động di chuyển qua lại giữa hai giới hạn.
    *   Khi người chơi bước vào vùng kiểm tra (`TriggerAreaCheck`), nó chuyển sang đuổi theo (`target`).
    *   Khi đến khoảng cách tấn công (`attackDistance`), nó dừng lại tấn công và chạy thời gian hồi chiêu (`Cooldown`).

### Lớp [FlyEnemy](file:///e:/game/UnityProjects/UnityChess3DPvPOnline/Demon-King-VS-Rambo-Frog-Hand_tracking-/Assets/Scripts/Enemy/FlyEnemy/FlyEnemy.cs)
Kẻ địch bay tuần tra theo các điểm định sẵn (`patrolPoints`).

*   **Hành vi:**
    *   Bay tuần tra tuần hoàn qua các điểm mốc.
    *   Khi người chơi bước vào tầm nhìn, nó đuổi theo (`Chase`).
    *   Có khả năng tấn công cận chiến hoặc bắn đạn tầm xa (`RangedAttack`).

---

## 5. Các Lớp Hỗ Trợ & Môi Trường

*   [AmmoPickup](file:///e:/game/UnityProjects/UnityChess3DPvPOnline/Demon-King-VS-Rambo-Frog-Hand_tracking-/Assets/Scripts/Items/AmmoPickup.cs): Hộp đạn trên bản đồ, khi người chơi chạm vào sẽ thêm đạn qua hàm `AddAmmo` trong `GunController`.
*   [HealthItem](file:///e:/game/UnityProjects/UnityChess3DPvPOnline/Demon-King-VS-Rambo-Frog-Hand_tracking-/Assets/Scripts/Items/HealthItem.cs): Vật phẩm hồi máu khi người chơi chạm vào.
*   [FallTrap](file:///e:/game/UnityProjects/UnityChess3DPvPOnline/Demon-King-VS-Rambo-Frog-Hand_tracking-/Assets/Scripts/FallTrap.cs): Bẫy rơi gây sát thương hoặc giết chết người chơi/kẻ địch khi va chạm.
*   [Deadzone](file:///e:/game/UnityProjects/UnityChess3DPvPOnline/Demon-King-VS-Rambo-Frog-Hand_tracking-/Assets/Scripts/Deadzone.cs): Vùng biên giới hạn dưới bản đồ, reset nhân vật hoặc tính là thua cuộc nếu rơi vào.
